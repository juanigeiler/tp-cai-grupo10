using System;
using System.Windows.Forms;
using Negocio;
using Datos;

namespace TemplateTPCorto
{
    public partial class FormPrimerLogin : Form
    {
        private Credencial _credencial;

        public FormPrimerLogin(Credencial credencial)
        {
            InitializeComponent();
            _credencial = credencial;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevaPassword.Text.Length < 8)
                {
                    MessageBox.Show("La contraseña debe tener al menos 8 caracteres");
                    return;
                }

                LoginNegocio loginNegocio = new LoginNegocio();
                loginNegocio.CambiarPasswordPrimerLogin(_credencial.Legajo, txtNuevaPassword.Text);

                MessageBox.Show("Contraseña cambiada exitosamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
