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
            try
            {
                string nuevaContraseña = txtNuevaContrasena.Text;
                bool requiereCambio;
                LoginNegocio loginNegocio = new LoginNegocio();
                var validacionLogin = loginNegocio.login(this.TextBoxUsuario.Text, TextBoxViejaContraseña.Text, out requiereCambio);

                ResetPasswordNegocio reset = new ResetPasswordNegocio();
                bool validacionNuevaContraseña = reset.CambiarContrasena(_credencial, nuevaContraseña);

                if (validacionNuevaContraseña && validacionLogin != null)
                {
                    UsuarioPersistencia persistencia = new UsuarioPersistencia();
                    persistencia.ActualizarContraseña(validacionLogin.Credencial.NombreUsuario,nuevaContraseña);

                    MessageBox.Show("Contraseña cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error de Excepcion");
            }
            
        }

        private void TextBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
