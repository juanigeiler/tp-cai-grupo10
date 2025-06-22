using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        private ProductoPersistencia productoPersistencia;

        public ProductoNegocio()
        {
            productoPersistencia = new ProductoPersistencia();
        }

        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> productos = productoPersistencia.obtenerProductosPorCategoria(categoria);            
            List<Producto> productosActivos = productos.Where(p => p.Stock > 0 && p.FechaBaja == null).ToList(); // logica de negocio: filtro los productos para mostar solo lo activos y con stock
            return productosActivos;
        }

        public List<Producto> obtenerProductosPorCategorias(List<string> categorias)
        {
            List<Producto> todosLosProductos = new List<Producto>();
            
            foreach (string categoria in categorias)
            {
                List<Producto> productosCategoria = obtenerProductosPorCategoria(categoria);
                todosLosProductos.AddRange(productosCategoria);
            }
            
            return todosLosProductos;
        }

        public List<ProductoVenta> generarListaProductosVenta(List<Tuple<Guid, int>> productosYCantidades, Guid idCliente, Guid idUsuario)
        {
            List<ProductoVenta> listaProductosVenta = new List<ProductoVenta>();
            
            foreach (var productoYCantidad in productosYCantidades)
            {
                Guid idProducto = productoYCantidad.Item1;
                int cantidad = productoYCantidad.Item2;
                ProductoVenta productoVenta = new ProductoVenta(idProducto, idCliente, idUsuario, cantidad);
                listaProductosVenta.Add(productoVenta);
            }
            
            return listaProductosVenta;
        }
    }
}