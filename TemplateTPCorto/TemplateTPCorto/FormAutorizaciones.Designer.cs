namespace TemplateTPCorto
{
    partial class FormAutorizaciones
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

        #region Código generado por el Diseñador de Windows Forms
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAutorizaciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelAcciones;

        private void InitializeComponent()
        {
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAutorizaciones = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelAcciones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizaciones)).BeginInit();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLegajo
            // 
            this.txtLegajo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtLegajo.Location = new System.Drawing.Point(15, 30);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(150, 25);
            this.txtLegajo.TabIndex = 0;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMotivo.Location = new System.Drawing.Point(15, 80);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(240, 60);
            this.txtMotivo.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(175, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAutorizar.FlatAppearance.BorderSize = 0;
            this.btnAutorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutorizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAutorizar.ForeColor = System.Drawing.Color.White;
            this.btnAutorizar.Location = new System.Drawing.Point(15, 150);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(115, 35);
            this.btnAutorizar.TabIndex = 3;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = false;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRechazar.FlatAppearance.BorderSize = 0;
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRechazar.ForeColor = System.Drawing.Color.White;
            this.btnRechazar.Location = new System.Drawing.Point(140, 150);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(115, 35);
            this.btnRechazar.TabIndex = 4;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Legajo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Motivo:";
            // 
            // dgvAutorizaciones
            // 
            this.dgvAutorizaciones.AllowUserToAddRows = false;
            this.dgvAutorizaciones.AllowUserToDeleteRows = false;
            this.dgvAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizaciones.Location = new System.Drawing.Point(30, 280);
            this.dgvAutorizaciones.Name = "dgvAutorizaciones";
            this.dgvAutorizaciones.ReadOnly = true;
            this.dgvAutorizaciones.Size = new System.Drawing.Size(424, 200);
            this.dgvAutorizaciones.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(306, 32);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Gestión de Autorizaciones";
            // 
            // panelAcciones
            // 
            this.panelAcciones.BackColor = System.Drawing.Color.White;
            this.panelAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAcciones.Controls.Add(this.label1);
            this.panelAcciones.Controls.Add(this.txtLegajo);
            this.panelAcciones.Controls.Add(this.btnBuscar);
            this.panelAcciones.Controls.Add(this.label2);
            this.panelAcciones.Controls.Add(this.txtMotivo);
            this.panelAcciones.Controls.Add(this.btnAutorizar);
            this.panelAcciones.Controls.Add(this.btnRechazar);
            this.panelAcciones.Location = new System.Drawing.Point(30, 70);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(275, 200);
            this.panelAcciones.TabIndex = 9;
            // 
            // FormAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(484, 501);
            this.Controls.Add(this.panelAcciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvAutorizaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAutorizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizaciones)).EndInit();
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

    }
} 