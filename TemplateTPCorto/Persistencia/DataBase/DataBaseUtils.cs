using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataBase
{
    public class DataBaseUtils
    {
        private readonly string rutaBase;

        public DataBaseUtils()
        {
            rutaBase = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas")
            );
            Console.WriteLine($"Ruta base inicializada: {rutaBase}");
        }

        public List<String> BuscarRegistro(String nombreArchivo)
        {
            String rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Console.WriteLine($"Buscando archivo: {rutaArchivo}");

            List<String> listado = new List<String>();

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine($"El archivo no existe: {rutaArchivo}");
                    return listado;
                }

                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        listado.Add(linea);
                    }
                }

                Console.WriteLine($"Líneas leídas: {listado.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo leer el archivo:");
                Console.WriteLine(e.Message);
            }
            return listado;
        }

        // Método para borrar un registro
        public void BorrarRegistro(string id, String nombreArchivo)
        {
            String rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Console.WriteLine($"Intentando borrar registro en: {rutaArchivo}");

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine($"El archivo no existe: {rutaArchivo}");
                    return;
                }

                List<string> listado = BuscarRegistro(nombreArchivo);
                var registrosRestantes = listado.Where(linea =>
                {
                    var campos = linea.Split(';');
                    return campos[0] != id;
                }).ToList();

                File.WriteAllLines(rutaArchivo, registrosRestantes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar borrar el registro:");
                Console.WriteLine(e.Message);
            }
        }

        // Método para agregar un registro
        public void AgregarRegistro(string nombreArchivo, string nuevoRegistro)
        {
            String rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Console.WriteLine($"Intentando agregar registro en: {rutaArchivo}");

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine($"El archivo no existe: {rutaArchivo}");
                    return;
                }

                bool saltoDeLinea = false;
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length > 0)
                    {
                        fs.Seek(-1, SeekOrigin.End);
                        int lastByte = fs.ReadByte();
                        saltoDeLinea = lastByte == '\n';
                    }
                }

                using (StreamWriter sw = new StreamWriter(rutaArchivo, append: true))
                {
                    if (!saltoDeLinea)
                    {
                        sw.WriteLine();
                    }
                    sw.WriteLine(nuevoRegistro);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar agregar el registro:");
                Console.WriteLine(e.Message);
            }
        }

        public void SobrescribirArchivo(string nombreArchivo, List<string> contenido)
        {
            String rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Console.WriteLine($"Intentando sobrescribir archivo: {rutaArchivo}");

            try
            {
                File.WriteAllLines(rutaArchivo, contenido);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar sobrescribir el archivo:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
