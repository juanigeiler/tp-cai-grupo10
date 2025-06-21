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

        private void InitializeComponent()
        {
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAutorizaciones = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // txtLegajo
            this.txtLegajo.Location = new System.Drawing.Point(120, 30);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(200, 26);
            this.txtLegajo.TabIndex = 0;

            // txtMotivo
            this.txtMotivo.Location = new System.Drawing.Point(120, 80);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(330, 60);
            this.txtMotivo.TabIndex = 1;

            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(350, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // btnAutorizar
            this.btnAutorizar.Location = new System.Drawing.Point(120, 150);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(200, 35);
            this.btnAutorizar.TabIndex = 3;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Legajo:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Motivo:";

            // dgvAutorizaciones
            this.dgvAutorizaciones.AllowUserToAddRows = false;
            this.dgvAutorizaciones.AllowUserToDeleteRows = false;
            this.dgvAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizaciones.Location = new System.Drawing.Point(30, 200);
            this.dgvAutorizaciones.Name = "dgvAutorizaciones";
            this.dgvAutorizaciones.ReadOnly = true;
            this.dgvAutorizaciones.Size = new System.Drawing.Size(420, 200);
            this.dgvAutorizaciones.TabIndex = 6;

            // FormAutorizaciones
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 424);
            this.Controls.Add(this.dgvAutorizaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtLegajo);
            this.Name = "FormAutorizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizaciones";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAutorizaciones;
    }
} 