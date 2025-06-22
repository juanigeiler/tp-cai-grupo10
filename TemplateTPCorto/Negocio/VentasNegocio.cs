using Datos;
using Datos.Ventas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio
    {
        private ProductoNegocio productoNegocio;
        private VentaPersistencia ventaPersistencia;

        public VentasNegocio()
        {
            productoNegocio = new ProductoNegocio();
            ventaPersistencia = new VentaPersistencia();
        }

        public List<Cliente> obtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            ClientePersistencia clientePersistencia = new ClientePersistencia();

            clientes = clientePersistencia.obtenerClientes();

            return clientes;
        }

        public List<CategoriaProductos> obtenerCategoriaProductos()
        {
            List<CategoriaProductos> categoriaProductos = new List<CategoriaProductos>();

            CategoriaProductos p1 = new CategoriaProductos("1", "Audio");
            categoriaProductos.Add(p1);

            CategoriaProductos p2 = new CategoriaProductos("2", "Celulares");
            categoriaProductos.Add(p2);

            CategoriaProductos p3 = new CategoriaProductos("3", "Electro Hogar");
            categoriaProductos.Add(p3);

            CategoriaProductos p4 = new CategoriaProductos("4", "Informática");
            categoriaProductos.Add(p4);

            CategoriaProductos p5 = new CategoriaProductos("5", "Smart TV");
            categoriaProductos.Add(p5);

            return categoriaProductos;
        }

        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            return productoNegocio.obtenerProductosPorCategoria(categoria);
        }

        public List<Producto> obtenerProductosPorCategorias(List<string> categorias)
        {
            return productoNegocio.obtenerProductosPorCategorias(categorias);
        }

        public List<ProductoVenta> generarListaProductosVenta(List<Tuple<Guid, int>> productosYCantidades, Guid idCliente, Guid idUsuario)
        {
            return productoNegocio.generarListaProductosVenta(productosYCantidades, idCliente, idUsuario);
        }

        public decimal CalcularDescuento(decimal subtotal)
        {
            decimal descuento = 0;
            // Promo Electro Hogar: 15% de descuento si la venta es mayor a $1,000,000
            if (subtotal > 1000000)
            {
                descuento = subtotal * 0.15m;
            }
            return descuento;
        }

        public bool procesarVenta(List<ProductoVenta> productosVenta)
        {
            return ventaPersistencia.agregarVentas(productosVenta);
        }

        public bool procesarVentaCompleta(List<Tuple<Guid, int>> productosYCantidades, Guid idCliente)
        {
            try
            {
                List<ProductoVenta> productosVenta = generarListaProductosVenta(productosYCantidades, idCliente, Guid.Empty);
                return procesarVenta(productosVenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar venta completa: " + ex.Message);
                return false;
            }
        }

    }
}