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
        public Credencial login(String username)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

            Credencial credencial = new Credencial(registros[0]);
            return credencial;
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
