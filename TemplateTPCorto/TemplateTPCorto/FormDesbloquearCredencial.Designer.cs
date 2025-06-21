namespace TemplateTPCorto
{
    partial class FormDesbloquearCredencial
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtLegajo
            this.txtLegajo.Location = new System.Drawing.Point(120, 30);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(200, 26);
            this.txtLegajo.TabIndex = 0;

            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(350, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // btnDesbloquear
            this.btnDesbloquear.Enabled = false;
            this.btnDesbloquear.Location = new System.Drawing.Point(120, 120);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(200, 35);
            this.btnDesbloquear.TabIndex = 2;
            this.btnDesbloquear.Text = "Desbloquear Usuario";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Legajo:";

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(30, 80);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(120, 20);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado: -";

            // FormDesbloquearCredencial
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 184);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtLegajo);
            this.Name = "FormDesbloquearCredencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desbloquear Credencial";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
    }
} 