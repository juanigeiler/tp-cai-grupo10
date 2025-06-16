using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
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

        public void RegistrarOperacion(Operacion operacion)
        {
            string archivo = "operaciones.csv";
            if (operacion.TipoOperacion == "CAMBIO_CREDENCIAL")
            {
                archivo = "operacion_cambio_credencial.csv";
            }
            else if (operacion.TipoOperacion == "CAMBIO_PERSONA")
            {
                archivo = "operacion_cambio_persona.csv";
            }

            _dataBaseUtils.AgregarRegistro(archivo, operacion.ToString());
        }

        public List<Operacion> ObtenerOperaciones()
        {
            List<Operacion> operaciones = new List<Operacion>();
            
            // Obtener operaciones generales
            var registros = _dataBaseUtils.BuscarRegistro("operaciones.csv");
            for (int i = 1; i < registros.Count; i++)
            {
                operaciones.Add(new Operacion(registros[i]));
            }

            // Obtener operaciones de cambio de credencial
            registros = _dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            for (int i = 1; i < registros.Count; i++)
            {
                operaciones.Add(new Operacion(registros[i]));
            }

            // Obtener operaciones de cambio de persona
            registros = _dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            for (int i = 1; i < registros.Count; i++)
            {
                operaciones.Add(new Operacion(registros[i]));
            }

            return operaciones.OrderByDescending(o => o.Fecha).ToList();
        }

        public void ActualizarEstadoOperacion(int idOperacion, string nuevoEstado)
        {
            string[] archivos = { "operaciones.csv", "operacion_cambio_credencial.csv", "operacion_cambio_persona.csv" };

            foreach (var archivo in archivos)
            {
                var registros = _dataBaseUtils.BuscarRegistro(archivo);
                for (int i = 1; i < registros.Count; i++)
                {
                    var operacion = new Operacion(registros[i]);
                    if (operacion.IdOperacion == idOperacion)
                    {
                        operacion.Estado = nuevoEstado;
                        registros[i] = operacion.ToString();
                        _dataBaseUtils.SobrescribirArchivo(archivo, registros);
                        return;
                    }
                }
            }
        }
    }
} 