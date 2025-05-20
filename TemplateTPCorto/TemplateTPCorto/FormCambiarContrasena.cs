using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Persistencia;

namespace TemplateTPCorto
{
    public partial class FormCambiarContrasena : Form
    {
        private Credencial _credencial;

        public FormCambiarContrasena(Credencial cred)
        {
            InitializeComponent();
            _credencial = cred;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nueva = txtNuevaContrasena.Text;

            ResetPasswordNegocio reset = new ResetPasswordNegocio();
            bool resultado = reset.CambiarContrasena(_credencial, nueva);

            if (resultado)
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "credenciales.txt");
                UsuarioPersistencia persistencia = new UsuarioPersistencia();
                persistencia.ActualizarCredencial(_credencial, ruta);

                MessageBox.Show("Contraseña cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtNuevaContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
