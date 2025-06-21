namespace TemplateTPCorto
{
    partial class FormCambiarContrasena
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
        private System.Windows.Forms.Label lblNuevaContrasena;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.Button btnConfirmar;

        private void InitializeComponent()
        {
            this.lblNuevaContrasena = new System.Windows.Forms.Label();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxViejaContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNuevaContrasena
            // 
            this.lblNuevaContrasena.AutoSize = true;
            this.lblNuevaContrasena.Location = new System.Drawing.Point(21, 133);
            this.lblNuevaContrasena.Name = "lblNuevaContrasena";
            this.lblNuevaContrasena.Size = new System.Drawing.Size(142, 20);
            this.lblNuevaContrasena.TabIndex = 0;
            this.lblNuevaContrasena.Text = "Nueva contraseña:";
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.Location = new System.Drawing.Point(23, 156);
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.PasswordChar = '*';
            this.txtNuevaContrasena.Size = new System.Drawing.Size(200, 26);
            this.txtNuevaContrasena.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(150, 233);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(200, 25);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese su Vieja Contraseña";
            // 
            // TextBoxViejaContraseña
            // 
            this.TextBoxViejaContraseña.Location = new System.Drawing.Point(23, 104);
            this.TextBoxViejaContraseña.Name = "TextBoxViejaContraseña";
            this.TextBoxViejaContraseña.PasswordChar = '*';
            this.TextBoxViejaContraseña.Size = new System.Drawing.Size(200, 26);
            this.TextBoxViejaContraseña.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese su Usuario";
            // 
            // TextBoxUsuario
            // 
            this.TextBoxUsuario.Location = new System.Drawing.Point(24, 52);
            this.TextBoxUsuario.Name = "TextBoxUsuario";
            this.TextBoxUsuario.Size = new System.Drawing.Size(200, 26);
            this.TextBoxUsuario.TabIndex = 4;
            this.TextBoxUsuario.TextChanged += new System.EventHandler(this.TextBoxUsuario_TextChanged);
            // 
            // FormCambiarContrasena
            // 
            this.ClientSize = new System.Drawing.Size(495, 298);
            this.Controls.Add(this.TextBoxViejaContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNuevaContrasena);
            this.Controls.Add(this.txtNuevaContrasena);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormCambiarContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxViejaContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxUsuario;
    }
}
