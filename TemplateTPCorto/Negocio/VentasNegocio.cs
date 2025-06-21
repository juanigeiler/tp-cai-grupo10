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
    }
}