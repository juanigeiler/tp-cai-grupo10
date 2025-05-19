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
            // Asegurarse de que el campo de contraseña oculte los caracteres
            txtPassword.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Debe completar usuario y contraseña");
                    return;
                }

                LoginNegocio loginNegocio = new LoginNegocio();
                var resultado = loginNegocio.login(txtUsuario.Text, txtPassword.Text);

                if (resultado.Credencial.EsPrimerLogin)
                {
                    FormPrimerLogin formPrimerLogin = new FormPrimerLogin(resultado.Credencial);
                    formPrimerLogin.ShowDialog();
                }

                FormPrincipal formPrincipal = new FormPrincipal(
                    resultado.Credencial,
                    resultado.Perfil,
                    resultado.Roles
                );
                this.Hide();
                formPrincipal.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}