using Datos;
using Datos.Ventas;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormCargarVenta : Form
    {
        private Cliente _cliente;
        private VentasNegocio _ventasNegocio;
        private List<Producto> _productosEnCarrito;

        public FormCargarVenta(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            _ventasNegocio = new VentasNegocio();
            _productosEnCarrito = new List<Producto>();
        }

        private void FormCargarVenta_Load(object sender, EventArgs e)
        {
            lblCliente.Text = $"Cliente: {_cliente.NombreCompleto}";
            CargarCategorias();
            ConfigurarGrids();
            ActualizarCarrito();
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = _ventasNegocio.obtenerCategoriaProductos();
                comboCategorias.DataSource = categorias;
                comboCategorias.DisplayMember = "Descripcion";
                comboCategorias.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrids()
        {
            // Configurar DataGridView de productos
            gridProductos.AutoGenerateColumns = false;
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Visible = false });
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 200 });
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 70 });
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock", DataPropertyName = "Stock", Width = 50 });

            // Configurar DataGridView del carrito
            gridCarrito.AutoGenerateColumns = false;
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Visible = false });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 200 });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 70 });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Stock", Width = 60 }); // Usamos 'Stock' para la cantidad
        }

        private void comboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategorias.SelectedValue != null)
            {
                string idCategoria = comboCategorias.SelectedValue.ToString();
                CargarProductos(idCategoria);
            }
        }

        private void CargarProductos(string idCategoria)
        {
            try
            {
                var productos = _ventasNegocio.obtenerProductosPorCategoria(idCategoria);
                gridProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (gridProductos.CurrentRow == null) return;

            var productoSeleccionado = (Producto)gridProductos.CurrentRow.DataBoundItem;
            int cantidad = (int)numericCantidad.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > productoSeleccionado.Stock)
            {
                MessageBox.Show("La cantidad solicitada supera el stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el producto ya está en el carrito
            var productoEnCarrito = _productosEnCarrito.FirstOrDefault(p => p.Id == productoSeleccionado.Id);
            if (productoEnCarrito != null)
            {
                // Actualizar cantidad si ya existe
                productoEnCarrito.Stock += cantidad;
            }
            else
            {
                // Clonar producto y agregarlo con la cantidad seleccionada
                var nuevoProductoParaCarrito = new Producto
                {
                    Id = productoSeleccionado.Id,
                    Nombre = productoSeleccionado.Nombre,
                    Precio = productoSeleccionado.Precio,
                    Stock = cantidad // Usamos Stock para guardar la cantidad
                };
                _productosEnCarrito.Add(nuevoProductoParaCarrito);
            }

            ActualizarCarrito();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridCarrito.CurrentRow == null) return;

            var productoSeleccionado = (Producto)gridCarrito.CurrentRow.DataBoundItem;
            _productosEnCarrito.Remove(productoSeleccionado);

            ActualizarCarrito();
        }

        private void ActualizarCarrito()
        {
            gridCarrito.DataSource = null;
            gridCarrito.DataSource = _productosEnCarrito;
            gridCarrito.Refresh();

            //TODO calcular subtotal
            numericCantidad.Value = 1;
        }

    }
} 