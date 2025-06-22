using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ProductoVenta
    {
        
        public Guid IdProducto { get; set; }

        public Guid IdCliente { get; set; }

        public Guid IdUsuario { get; set; }

        public int Cantidad { get; set; }

        public ProductoVenta(Guid idProducto, Guid idCliente, Guid idUsuario, int cantidad)
        {
            IdProducto = idProducto;
            IdCliente = idCliente;
            IdUsuario = idUsuario;
            Cantidad = cantidad;
        }
    }
}
