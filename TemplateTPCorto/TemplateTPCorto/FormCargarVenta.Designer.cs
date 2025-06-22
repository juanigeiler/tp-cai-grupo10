namespace TemplateTPCorto
{
    partial class FormCargarVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblCliente = new System.Windows.Forms.Label();
            this.comboCategorias = new System.Windows.Forms.ComboBox();
            this.gridProductos = new System.Windows.Forms.DataGridView();
            this.gridCarrito = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.panelCarrito = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.panelProductos.SuspendLayout();
            this.panelCarrito.SuspendLayout();
            this.SuspendLayout();

            // lblCliente
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(12, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(200, 21);
            this.lblCliente.Text = "Cliente:";

            // panelProductos
            this.panelProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductos.Controls.Add(this.label1);
            this.panelProductos.Controls.Add(this.comboCategorias);
            this.panelProductos.Controls.Add(this.gridProductos);
            this.panelProductos.Location = new System.Drawing.Point(16, 40);
            this.panelProductos.Size = new System.Drawing.Size(400, 450);

            // label1 (Seleccionar Categoría)
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Text = "Seleccionar Categoría:";

            // comboCategorias
            this.comboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboCategorias.Location = new System.Drawing.Point(18, 35);
            this.comboCategorias.Size = new System.Drawing.Size(360, 25);
            this.comboCategorias.SelectedIndexChanged += new System.EventHandler(this.comboCategorias_SelectedIndexChanged);

            // gridProductos
            this.gridProductos.Location = new System.Drawing.Point(18, 70);
            this.gridProductos.Size = new System.Drawing.Size(360, 360);
            this.gridProductos.SelectionChanged += new System.EventHandler(this.gridProductos_SelectionChanged);
            // (Otras propiedades de gridProductos se establecen en el constructor)

            // btnAgregar
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(425, 225);
            this.btnAgregar.Size = new System.Drawing.Size(50, 50);
            this.btnAgregar.Text = ">>";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // panelCarrito
            this.panelCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCarrito.Controls.Add(this.label2);
            this.panelCarrito.Controls.Add(this.gridCarrito);
            this.panelCarrito.Controls.Add(this.label3);
            this.panelCarrito.Controls.Add(this.numericCantidad);
            this.panelCarrito.Controls.Add(this.btnEliminar);
            this.panelCarrito.Controls.Add(this.lblSubtotal);
            this.panelCarrito.Controls.Add(this.lblDescuento);
            this.panelCarrito.Controls.Add(this.lblTotal);
            this.panelCarrito.Controls.Add(this.btnConfirmarVenta);
            this.panelCarrito.Location = new System.Drawing.Point(485, 40);
            this.panelCarrito.Size = new System.Drawing.Size(430, 450);

            // label2 (Carrito)
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Text = "Carrito";
            
            // gridCarrito
            this.gridCarrito.Location = new System.Drawing.Point(15, 40);
            this.gridCarrito.Size = new System.Drawing.Size(400, 200);
            this.gridCarrito.SelectionChanged += new System.EventHandler(this.gridCarrito_SelectionChanged);
            // (Otras propiedades de gridCarrito se establecen en el constructor)

            // label3 (Cantidad)
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 255);
            this.label3.Text = "Cantidad:";
            
            // numericCantidad
            this.numericCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numericCantidad.Location = new System.Drawing.Point(80, 250);
            this.numericCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(315, 250);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // lblSubtotal
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtotal.Location = new System.Drawing.Point(15, 330);
            this.lblSubtotal.Size = new System.Drawing.Size(400, 20);
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubtotal.Text = "Subtotal: $0.00";

            // lblDescuento
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.ForeColor = System.Drawing.Color.Green;
            this.lblDescuento.Location = new System.Drawing.Point(15, 355);
            this.lblDescuento.Size = new System.Drawing.Size(400, 20);
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDescuento.Text = "Descuento: $0.00";

            // lblTotal
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(15, 380);
            this.lblTotal.Size = new System.Drawing.Size(400, 24);
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Text = "Total: $0.00";

            // btnConfirmarVenta
            this.btnConfirmarVenta.Location = new System.Drawing.Point(265, 410);
            this.btnConfirmarVenta.Size = new System.Drawing.Size(150, 30);
            this.btnConfirmarVenta.Text = "Confirmar Venta";
            this.btnConfirmarVenta.Click += new System.EventHandler(this.btnConfirmarVenta_Click);
            
            // FormCargarVenta
            this.ClientSize = new System.Drawing.Size(930, 510);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelCarrito);
            this.Name = "FormCargarVenta";
            this.Text = "Cargar Venta";
            this.Load += new System.EventHandler(this.FormCargarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.panelProductos.ResumeLayout(false);
            this.panelProductos.PerformLayout();
            this.panelCarrito.ResumeLayout(false);
            this.panelCarrito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox comboCategorias;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.DataGridView gridCarrito;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelCarrito;
    }
}
