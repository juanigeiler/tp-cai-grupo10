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
using System.Threading.Tasks;

namespace TemplateTPCorto
{
    public partial class FormCambiarContrasena : Form
    {
        private Credencial _credencial;

        public FormCambiarContrasena(Credencial cred = null)
        {
            InitializeComponent();
            _credencial = cred;
            if (_credencial != null)
            {
                TextBoxUsuario.Text = _credencial.NombreUsuario;
                TextBoxUsuario.Enabled = false;

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string usuario = TextBoxUsuario.Text;
            string viejaContrasena = TextBoxViejaContraseña.Text;
            string nuevaContrasena = txtNuevaContrasena.Text;

            try
            {
                Credencial credencial = _credencial;
                
                if (credencial == null)
                {
                    LoginNegocio loginNegocio = new LoginNegocio();
                    credencial = loginNegocio.verificarUserCambioContraseña(usuario, viejaContrasena);

                    if (credencial == null)
                    {
                        MessageBox.Show("Usuario o contraseña actual incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (credencial.Contrasena != viejaContrasena)
                {
                    MessageBox.Show("Su Contraseña no coincide con la anterior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ResetPasswordNegocio reset = new ResetPasswordNegocio();
                bool cambioOk = reset.CambiarContrasena(credencial, nuevaContrasena);

                if (cambioOk)
                {
                    UsuarioPersistencia persistencia = new UsuarioPersistencia();
                    persistencia.ActualizarContraseña(credencial.NombreUsuario, nuevaContrasena);

                    MessageBox.Show("Contraseña cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar la contraseña. Verificá los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
