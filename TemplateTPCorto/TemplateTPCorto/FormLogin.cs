using Datos;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            bool requiereCambio;
            LoginNegocio loginNegocio = new LoginNegocio();
            Credencial credencial = loginNegocio.login(usuario, password, out requiereCambio); 

        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();
            bool requiereCambio;

            Credencial cred = loginNegocio.login(usuario, password, out requiereCambio);

            if (cred == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormCambiarContrasena cambiar = new FormCambiarContrasena(cred);
            cambiar.ShowDialog();
        }
    }
}
