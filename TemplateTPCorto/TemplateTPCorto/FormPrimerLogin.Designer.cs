namespace TemplateTPCorto
{
    partial class FormPrimerLogin
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNuevaPassword = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Primer ingreso - Debe cambiar su contraseña";
            // 
            // lblNuevaPassword
            // 
            this.lblNuevaPassword.AutoSize = true;
            this.lblNuevaPassword.Location = new System.Drawing.Point(13, 50);
            this.lblNuevaPassword.Name = "lblNuevaPassword";
            this.lblNuevaPassword.Size = new System.Drawing.Size(96, 13);
            this.lblNuevaPassword.TabIndex = 1;
            this.lblNuevaPassword.Text = "Nueva Contraseña:";
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Location = new System.Drawing.Point(115, 47);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.PasswordChar = '*';
            this.txtNuevaPassword.Size = new System.Drawing.Size(228, 20);
            this.txtNuevaPassword.TabIndex = 2;
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(115, 85);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(228, 23);
            this.btnCambiar.TabIndex = 3;
            this.btnCambiar.Text = "Cambiar Contraseña";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // FormPrimerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 131);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.txtNuevaPassword);
            this.Controls.Add(this.lblNuevaPassword);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrimerLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambio de Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNuevaPassword;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Button btnCambiar;
    }
}