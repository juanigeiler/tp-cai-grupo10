using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ProductoPersistencia
    {
        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> listadoProductos = new List<Producto>();

            try
            {
                // Llamo al WS
                HttpResponseMessage response = WebHelper.Get("/api/Producto/TraerProductosPorCategoria?catnum=" + categoria);

                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    listadoProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
                }
            }
            catch (Exception ex)
            {
                // Log del error - en un entorno real se debería usar un logger
                Console.WriteLine("Error al obtener productos por categoría: " + ex.Message);
            }

            return listadoProductos;
        }

        public Producto obtenerProductoPorId(Guid idProducto)
        {
            Producto producto = null;

            try
            {
                // Llamo al WS para obtener un producto específico
                HttpResponseMessage response = WebHelper.Get("/api/Producto/TraerProducto?id=" + idProducto.ToString());

                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var contentStream = response.Content.ReadAsStringAsync().Result;
                    producto = JsonConvert.DeserializeObject<Producto>(contentStream);
                }
            }
            catch (Exception ex)
            {
                // Log del error
                Console.WriteLine("Error al obtener producto por ID: " + ex.Message);
            }

            return producto;
        }

        public bool validarStockProducto(Guid idProducto, int cantidadSolicitada)
        {
            Producto producto = obtenerProductoPorId(idProducto);
            
            if (producto != null)
            {
                return producto.Stock >= cantidadSolicitada;
            }
            
            return false;
        }
    }
}