using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Persistencia
{
    public class OperacionPersistencia
    {
        private DataBaseUtils _dataBaseUtils;

        public OperacionPersistencia()
        {
            _dataBaseUtils = new DataBaseUtils();
        }

        public int ObtenerSiguienteId()
        {
            string[] archivos = { "operacion_cambio_credencial.csv", "operacion_cambio_persona.csv" };
            int maxId = 0;

            foreach (var archivo in archivos)
            {
                var registros = _dataBaseUtils.BuscarRegistro(archivo);
                for (int i = 1; i < registros.Count; i++)
                {
                    var campos = registros[i].Split(';');
                    if (campos.Length > 0 && int.TryParse(campos[0], out int id))
                    {
                        if (id > maxId)
                        {
                            maxId = id;
                        }
                    }
                }
            }
            return maxId + 1;
        }

        public int ObtenerSiguienteIdAutorizacion()
        {
            string archivo = "autorizacion.csv";
            int maxId = 0;
            var registros = _dataBaseUtils.BuscarRegistro(archivo);
            for (int i = 1; i < registros.Count; i++)
            {
                var campos = registros[i].Split(';');
                if (campos.Length > 0 && int.TryParse(campos[0], out int id))
                {
                    if (id > maxId) maxId = id;
                }
            }
            return maxId + 1;
        }

        public void RegistrarAutorizacion(int idOperacion, string tipoOperacion, string motivo, string estado)
        {
            string archivo = "autorizacion.csv";
            string ruta = _dataBaseUtils.ObtenerRuta(archivo);

            if (!File.Exists(ruta))
            {
                string header = "idAutorizacion;idOperacion;tipoOperacion;motivo;estado;fecha" + Environment.NewLine;
                File.WriteAllText(ruta, header);
            }
            
            int idAutorizacion = ObtenerSiguienteIdAutorizacion();
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            string registro = $"{idAutorizacion};{idOperacion};{tipoOperacion};{motivo};{estado};{fecha}";
            
            _dataBaseUtils.AgregarRegistro(archivo, registro);
        }

        public void RegistrarOperacion(Operacion operacion)
        {
            string archivo = "";
            string registro = "";

            if (operacion.TipoOperacion == "CAMBIO_CREDENCIAL")
            {
                archivo = "operacion_cambio_credencial.csv";
                registro = $"{operacion.IdOperacion};{operacion.Legajo};{operacion.TipoOperacion};{operacion.Descripcion};{operacion.Fecha}";
            }
            else if (operacion.TipoOperacion == "CAMBIO_PERSONA")
            {
                archivo = "operacion_cambio_persona.csv";
                registro = operacion.ToString();
            }

            if (!string.IsNullOrEmpty(archivo))
            {
                _dataBaseUtils.AgregarRegistro(archivo, registro);
            }
        }

        public List<Operacion> ObtenerOperaciones()
        {
            List<Operacion> operaciones = new List<Operacion>();

            var registrosCredencial = _dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            for (int i = 1; i < registrosCredencial.Count; i++)
            {
                string[] datos = registrosCredencial[i].Split(';');
                if (datos.Length == 5)
                {
                    var op = new Operacion
                    {
                        IdOperacion = int.Parse(datos[0]),
                        Legajo = datos[1],
                        TipoOperacion = datos[2],
                        Descripcion = datos[3],
                        Fecha = datos[4],
                        Estado = "PENDIENTE"
                    };
                    operaciones.Add(op);
                }
            }

            var registrosPersona = _dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            for (int i = 1; i < registrosPersona.Count; i++)
            {
                string[] datos = registrosPersona[i].Split(';');
                if (datos.Length == 6) 
                {
                    var op = new Operacion
                    {
                        IdOperacion = int.Parse(datos[0]),
                        Legajo = datos[1],
                        TipoOperacion = "CAMBIO_PERSONA",
                        Descripcion = $"Solicitud para {datos[1]}: {datos[2]} {datos[3]}, DNI: {datos[4]}",
                        Fecha = datos[5],
                        Estado = "PENDIENTE"
                    };
                    operaciones.Add(op);
                }
            }

            return operaciones.OrderByDescending(o => o.IdOperacion).ToList();
        }

        public void AutorizarCambioPersona(int idOperacion)
        {
            string archivoOperaciones = "operacion_cambio_persona.csv";
            var operaciones = _dataBaseUtils.BuscarRegistro(archivoOperaciones);
            string operacionARealizar = null;
            int indiceOperacion = -1;

            for (int i = 1; i < operaciones.Count; i++)
            {
                var campos = operaciones[i].Split(';');
                if (campos.Length > 0 && int.TryParse(campos[0], out int id) && id == idOperacion)
                {
                    operacionARealizar = operaciones[i];
                    indiceOperacion = i;
                    break;
                }
            }
            
            if (operacionARealizar == null)
            {
                throw new Exception("Operación de cambio de persona no encontrada.");
            }

            var camposOp = operacionARealizar.Split(';');
            string legajo = camposOp[1];
            string nombreNuevo = camposOp[2];
            string apellidoNuevo = camposOp[3];
            string dniNuevo = camposOp[4];
            
            string archivoPersonas = "persona.csv";
            var personas = _dataBaseUtils.BuscarRegistro(archivoPersonas);
            bool personaModificada = false;
            for (int i = 1; i < personas.Count; i++)
            {
                var camposPersona = personas[i].Split(';');
                if (camposPersona.Length > 1 && camposPersona[0] == legajo)
                {
                    camposPersona[1] = nombreNuevo;
                    camposPersona[2] = apellidoNuevo;
                    camposPersona[3] = dniNuevo;
                    personas[i] = string.Join(";", camposPersona);
                    personaModificada = true;
                    break;
                }
            }

            if (!personaModificada)
            {
                throw new Exception("No se encontró la persona a modificar en el archivo de personas.");
            }

            operaciones.RemoveAt(indiceOperacion);
            _dataBaseUtils.SobrescribirArchivo(archivoOperaciones, operaciones);
            _dataBaseUtils.SobrescribirArchivo(archivoPersonas, personas);
        }

        public void RechazarCambioPersona(int idOperacion)
        {
            string archivoOperaciones = "operacion_cambio_persona.csv";
            var operaciones = _dataBaseUtils.BuscarRegistro(archivoOperaciones);
            int indiceOperacion = -1;

            for (int i = 1; i < operaciones.Count; i++)
            {
                var campos = operaciones[i].Split(';');
                if (campos.Length > 0 && int.TryParse(campos[0], out int id) && id == idOperacion)
                {
                    indiceOperacion = i;
                    break;
                }
            }

            if (indiceOperacion != -1)
            {
                operaciones.RemoveAt(indiceOperacion);
                _dataBaseUtils.SobrescribirArchivo(archivoOperaciones, operaciones);
            }
            else
            {
                throw new Exception("Operación de cambio de persona no encontrada para rechazar.");
            }
        }

        public void ProcesarCambioCredencial(int idOperacion, bool autorizar)
        {
            string archivoOperaciones = "operacion_cambio_credencial.csv";
            var operaciones = _dataBaseUtils.BuscarRegistro(archivoOperaciones);
            string legajoADesbloquear = null;
            int indiceOperacion = -1;

            for (int i = 1; i < operaciones.Count; i++)
            {
                var campos = operaciones[i].Split(';');
                if (campos.Length > 1 && int.TryParse(campos[0], out int id) && id == idOperacion)
                {
                    legajoADesbloquear = campos[1];
                    indiceOperacion = i;
                    break;
                }
            }

            if (indiceOperacion == -1)
            {
                throw new Exception("Operación de cambio de credencial no encontrada.");
            }

            if (autorizar)
            {
                string archivoBloqueados = "usuario_bloqueado.csv";
                var bloqueados = _dataBaseUtils.BuscarRegistro(archivoBloqueados);
                var bloqueadoEncontrado = bloqueados.FirstOrDefault(line => line.Trim() == legajoADesbloquear);
                
                if (bloqueadoEncontrado != null)
                {
                    bloqueados.Remove(bloqueadoEncontrado);
                    _dataBaseUtils.SobrescribirArchivo(archivoBloqueados, bloqueados);
                }
            }
            operaciones.RemoveAt(indiceOperacion);
            _dataBaseUtils.SobrescribirArchivo(archivoOperaciones, operaciones);
        }

        public void ActualizarEstadoOperacion(int idOperacion, string nuevoEstado)
        {
            string[] archivos = { "operacion_cambio_credencial.csv" };

            foreach (var archivo in archivos)
            {
                var registros = _dataBaseUtils.BuscarRegistro(archivo);
                bool modificado = false;
                for (int i = 1; i < registros.Count; i++)
                {
                    var campos = registros[i].Split(';');
                    if (campos.Length > 5 && int.TryParse(campos[0], out int id) && id == idOperacion)
                    {
                        campos[5] = nuevoEstado; 
                        registros[i] = string.Join(";", campos);
                        modificado = true;
                        break;
                    }
                }
                if (modificado)
                {
                    _dataBaseUtils.SobrescribirArchivo(archivo, registros);
                    return;
                }
            }
        }
    }
} 