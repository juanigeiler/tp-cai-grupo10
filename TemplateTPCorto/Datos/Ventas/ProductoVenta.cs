using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ProductoVenta
    {
        Guid idProducto { get; set; }
        Guid idCliente { get; set; }
        Guid idUsuario { get; set; }
        int cantidad { get; set; }

    }
}
