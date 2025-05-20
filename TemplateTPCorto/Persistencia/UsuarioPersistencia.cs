using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {

        public Credencial ObtenerCredencialPorNombreUsuario(string nombreUsuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

            for (int i = 1; i < registros.Count; i++)
            {
                string registro = registros[i];
                Credencial credencial = new Credencial(registro);

                if (credencial.NombreUsuario == nombreUsuario)
                {
                    return credencial;
                }
            }
            return null;
        }

        public bool EstaBloqueado(string legajoUsuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> registros = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");

            for (int i = 1; i < registros.Count; i++)
            {
                string legajo = registros[i];

                if (legajo == legajoUsuario)
                {
                    return true;
                }
            }

            return false;
        }

        public int CantidadIntentosUsuario(string legajoUsuario) {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> registros = dataBaseUtils.BuscarRegistro("login_intentos.csv");

            int cantidadIntentos = 0;
            for (int i = 1; i < registros.Count; i++)
            {
                string[] campos = registros[i].Split(';');

                if (campos.Length >= 1 && campos[0] == legajoUsuario)
                {
                    cantidadIntentos++;
                }
            }

            return cantidadIntentos;
        }

        public void BloquearUsuario(string legajoUsuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajoUsuario);
        }

        public void RegistrarIntentoFallido(string legajoUsuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.AgregarRegistro("login_intentos.csv", legajoUsuario + ";" + DateTime.Now.ToString("d/M/yyyy"));
        }

        public void LimpiarIntentosFallidos(string legajoUsuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<string> registros = dataBaseUtils.BuscarRegistro("login_intentos.csv");

            for (int i = 1; i < registros.Count; i++)
            {
                string linea = registros[i];
                string[] campos = linea.Split(';');

                if (campos[0] == legajoUsuario)
                {
                    dataBaseUtils.BorrarRegistro(legajoUsuario, "");
                }
            }
        }

        public void ActualizarFechaUltimoLogin(string legajo, DateTime fecha)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<string> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

            for (int i = 1; i < registros.Count; i++)
            {
                Credencial c = new Credencial(registros[i]);
                if (c.Legajo == legajo)
                {
                    c.FechaUltimoLogin = fecha;
                    registros[i] = $"{c.Legajo};{c.NombreUsuario};{c.Contrasena};{c.FechaAlta.ToString("d/M/yyyy")};{fecha.ToString("d/M/yyyy")}";
                    break;
                }
            }

            dataBaseUtils.SobrescribirArchivo("", registros);
        }

        public void ActualizarCredencial(Credencial credencial, string rutaArchivo)
        {
            List<string> lineas = File.ReadAllLines(rutaArchivo).ToList();

            for (int i = 0; i < lineas.Count; i++)
            {
                string[] partes = lineas[i].Split(';');
                if (partes[0] == credencial.Legajo)
                {
                    string nuevaLinea = string.Join(";",
                        credencial.Legajo,
                        credencial.NombreUsuario,
                        credencial.Contrasena,
                        credencial.FechaAlta.ToString("d/M/yyyy"),
                        credencial.FechaUltimoLogin.ToString("d/M/yyyy")
                    );

                    lineas[i] = nuevaLinea;
                    break;
                }
            }

            File.WriteAllLines(rutaArchivo, lineas);
        }
    }
}
