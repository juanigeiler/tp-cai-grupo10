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
            // Obtener todos los productos de la categoría desde la persistencia
            List<Producto> productos = productoPersistencia.obtenerProductosPorCategoria(categoria);
            
            // Aplicar lógica de negocio: filtrar solo productos con stock positivo
            List<Producto> productosConStock = productos.Where(p => p.Stock > 0).ToList();
            
            return productosConStock;
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

        public bool validarStockProducto(Guid idProducto, int cantidadSolicitada)
        {
            return productoPersistencia.validarStockProducto(idProducto, cantidadSolicitada);
        }

        public List<ProductoVenta> generarListaProductosVenta(List<Tuple<Guid, int>> productosYCantidades, Guid idCliente, Guid idUsuario)
        {
            List<ProductoVenta> listaProductosVenta = new List<ProductoVenta>();
            
            foreach (var productoYCantidad in productosYCantidades)
            {
                Guid idProducto = productoYCantidad.Item1;
                int cantidad = productoYCantidad.Item2;
                
                // Validar stock antes de agregar a la lista
                if (validarStockProducto(idProducto, cantidad))
                {
                    // El idUsuario se asignará en la capa de persistencia, aquí lo dejamos vacío.
                    ProductoVenta productoVenta = new ProductoVenta(idProducto, idCliente, idUsuario, cantidad);
                    listaProductosVenta.Add(productoVenta);
                }
                else
                {
                    // Si no hay stock suficiente, no se agrega a la lista
                    // En un entorno real, se podría lanzar una excepción o manejar de otra forma
                    throw new InvalidOperationException($"Stock insuficiente para el producto {idProducto}");
                }
            }
            
            return listaProductosVenta;
        }

        public bool validarStockListaProductos(List<ProductoVenta> productosVenta)
        {
            foreach (ProductoVenta productoVenta in productosVenta)
            {
                // Aquí se implementaría la validación de stock para cada producto
                // Por ahora retornamos true como placeholder
                if (!validarStockProducto(productoVenta.IdProducto, productoVenta.Cantidad))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}