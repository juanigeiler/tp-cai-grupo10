namespace TemplateTPCorto
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelVenta = new System.Windows.Forms.Panel();
            this.labelInstruccion = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboClientes = new System.Windows.Forms.ComboBox();
            this.panelContenido.SuspendLayout();
            this.panelVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 600);
            this.panelMenu.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblBienvenida.Location = new System.Drawing.Point(22, 18);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(199, 25);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido al Sistema";
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContenido.Controls.Add(this.panelVenta);
            this.panelContenido.Controls.Add(this.lblBienvenida);
            this.panelContenido.Location = new System.Drawing.Point(200, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(684, 600);
            this.panelContenido.TabIndex = 2;
            // 
            // panelVenta
            // 
            this.panelVenta.BackColor = System.Drawing.Color.White;
            this.panelVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVenta.Controls.Add(this.labelInstruccion);
            this.panelVenta.Controls.Add(this.labelCliente);
            this.panelVenta.Controls.Add(this.comboClientes);
            this.panelVenta.Location = new System.Drawing.Point(27, 60);
            this.panelVenta.Name = "panelVenta";
            this.panelVenta.Size = new System.Drawing.Size(400, 150);
            this.panelVenta.TabIndex = 3;
            // 
            // labelInstruccion
            // 
            this.labelInstruccion.AutoSize = true;
            this.labelInstruccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelInstruccion.Location = new System.Drawing.Point(15, 85);
            this.labelInstruccion.Name = "labelInstruccion";
            this.labelInstruccion.Size = new System.Drawing.Size(342, 13);
            this.labelInstruccion.TabIndex = 2;
            this.labelInstruccion.Text = "Para iniciar una venta, seleccione un cliente y haga clic en \'Cargar Venta\'";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelCliente.Location = new System.Drawing.Point(15, 20);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(127, 17);
            this.labelCliente.TabIndex = 1;
            this.labelCliente.Text = "Seleccione un Cliente:";
            // 
            // comboClientes
            // 
            this.comboClientes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.Location = new System.Drawing.Point(18, 45);
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(360, 25);
            this.comboClientes.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 600);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 639);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Principal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.panelVenta.ResumeLayout(false);
            this.panelVenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.Panel panelVenta;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelInstruccion;
    }
}