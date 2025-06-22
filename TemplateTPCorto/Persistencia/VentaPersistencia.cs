using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia
    {
        private Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

        public bool agregarVentas(List<ProductoVenta> listaproductos)
        {
            if (listaproductos == null || listaproductos.Count == 0)
            {
                return false;
            }

            try
            {
                foreach (ProductoVenta productoVenta in listaproductos)
                {
                    productoVenta.IdUsuario = this.idUsuario;
                    var jsonRequest = JsonConvert.SerializeObject(productoVenta);
                    HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error al agregar venta para producto {productoVenta.IdProducto}: {response.StatusCode}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar las ventas: " + ex.Message);
                return false;
            }
        }
    }
}