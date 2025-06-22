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
        private class ProductoEnCarrito
        {
            private readonly Producto _producto;
            public int Cantidad { get; set; }

            public ProductoEnCarrito(Producto producto, int cantidad)
            {
                _producto = producto;
                Cantidad = cantidad;
            }

            public Guid Id => _producto.Id;
            public string Nombre => _producto.Nombre;
            public int Precio => _producto.Precio;
            public int StockDisponible => _producto.Stock;
        }

        private Cliente _cliente;
        private VentasNegocio _ventasNegocio;
        private List<ProductoEnCarrito> _productosEnCarrito;

        public FormCargarVenta(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            _ventasNegocio = new VentasNegocio();
            _productosEnCarrito = new List<ProductoEnCarrito>();
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
                comboCategorias.DisplayMember = "DisplayText";
                comboCategorias.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrids()
        {
            // Estilo general
            this.BackColor = Color.FromArgb(240, 240, 240);
            
            // Estilo de botones
            btnAgregar.BackColor = Color.FromArgb(40, 167, 69); // Verde
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnEliminar.BackColor = Color.FromArgb(220, 53, 69); // Rojo
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnConfirmarVenta.BackColor = Color.FromArgb(0, 123, 255); // Azul primario
            btnConfirmarVenta.FlatStyle = FlatStyle.Flat;
            btnConfirmarVenta.FlatAppearance.BorderSize = 0;
            btnConfirmarVenta.ForeColor = Color.White;
            btnConfirmarVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Estilo de DataGridView
            ConfigurarEstiloGrid(gridProductos);
            ConfigurarEstiloGrid(gridCarrito);

            // Limpiar columnas para evitar duplicados en recargas
            gridProductos.Columns.Clear();
            gridCarrito.Columns.Clear();

            // Configurar columnas de productos
            gridProductos.AutoGenerateColumns = false;
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 250, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 100, DefaultCellStyle = { Format = "C2" } });
            gridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock", DataPropertyName = "Stock", Width = 70 });

            // Configurar columnas del carrito
            gridCarrito.AutoGenerateColumns = false;
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Visible = false });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = { Format = "C2" } });
            gridCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 60 });
        }

        private void ConfigurarEstiloGrid(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.BackgroundColor = Color.White;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 62, 80);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
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
            int cantidadAAgregar = (int)numericCantidad.Value;

            if (cantidadAAgregar <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidadAAgregar > productoSeleccionado.Stock)
            {
                MessageBox.Show($"La cantidad solicitada ({cantidadAAgregar}) supera el stock disponible ({productoSeleccionado.Stock}).", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoEnCarrito = _productosEnCarrito.FirstOrDefault(p => p.Id == productoSeleccionado.Id);
            
            if (productoEnCarrito != null)
            {
                int cantidadPrevia = productoEnCarrito.Cantidad;
                if (cantidadPrevia + cantidadAAgregar > productoSeleccionado.Stock)
                {
                    MessageBox.Show($"No se puede agregar. La cantidad en carrito ({cantidadPrevia}) más la cantidad a agregar ({cantidadAAgregar}) supera el stock disponible ({productoSeleccionado.Stock}).", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                productoEnCarrito.Cantidad += cantidadAAgregar;
            }
            else
            {
                _productosEnCarrito.Add(new ProductoEnCarrito(productoSeleccionado, cantidadAAgregar));
            }

            ActualizarCarrito();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridCarrito.CurrentRow == null) return;

            var itemSeleccionado = (ProductoEnCarrito)gridCarrito.CurrentRow.DataBoundItem;
            _productosEnCarrito.Remove(itemSeleccionado);

            ActualizarCarrito();
        }

        private void ActualizarCarrito()
        {
            gridCarrito.DataSource = null;
            if (_productosEnCarrito.Any())
            {
                gridCarrito.DataSource = _productosEnCarrito;
            }
            gridCarrito.Refresh();

            CalcularTotales();
            numericCantidad.Value = 1;
            btnEliminar.Enabled = false;
        }

        private void CalcularTotales()
        {
            decimal subtotal = _productosEnCarrito.Sum(p => p.Precio * p.Cantidad);
            decimal descuento = _ventasNegocio.CalcularDescuento(subtotal);
            decimal totalFinal = subtotal - descuento;

            lblSubtotal.Text = $"Subtotal: ${subtotal:N2}";
            lblDescuento.Text = $"Descuento: -${descuento:N2}";
            lblTotal.Text = $"Total: ${totalFinal:N2}";
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (_productosEnCarrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var productosVenta = _productosEnCarrito.Select(p =>
                    new Tuple<Guid, int>(p.Id, p.Cantidad)
                ).ToList();

                bool ventaExitosa = _ventasNegocio.procesarVentaCompleta(productosVenta, _cliente.Id);

                if (ventaExitosa)
                {
                    MessageBox.Show("Venta realizada con éxito.", "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo procesar la venta. Verifique el stock e intente nuevamente.", "Error en Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProductos.CurrentRow != null && gridProductos.CurrentRow.DataBoundItem is Producto)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        private void gridCarrito_SelectionChanged(object sender, EventArgs e)
        {
            btnEliminar.Enabled = gridCarrito.SelectedRows.Count > 0;
        }
    }
} 