using System;
using System.Windows.Forms;
using Persistencia;
using Datos;

namespace TemplateTPCorto
{
    public partial class FormDesbloquearCredencial : Form
    {
        private UsuarioPersistencia _usuarioPersistencia;
        private OperacionPersistencia _operacionPersistencia;
        private string _legajoActual;

        public FormDesbloquearCredencial()
        {
            InitializeComponent();
            _usuarioPersistencia = new UsuarioPersistencia();
            _operacionPersistencia = new OperacionPersistencia();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLegajo.Text))
                {
                    MessageBox.Show("Por favor ingrese un legajo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool estaBloqueado = _usuarioPersistencia.EstaBloqueado(txtLegajo.Text);
                if (estaBloqueado)
                {
                    btnDesbloquear.Enabled = true;
                    lblEstado.Text = "Estado: BLOQUEADO";
                    lblEstado.ForeColor = System.Drawing.Color.Red;
                    _legajoActual = txtLegajo.Text;
                }
                else
                {
                    btnDesbloquear.Enabled = false;
                    lblEstado.Text = "Estado: NO BLOQUEADO";
                    lblEstado.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLegajo.Text))
                {
                    MessageBox.Show("Por favor ingrese un legajo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Registrar la operación
                string registroOperacion = $"{DateTime.Now.Millisecond};{_legajoActual};CAMBIO_CREDENCIAL;Desbloqueo de credencial y cambio de contraseña;{DateTime.Now.ToString("d/M/yyyy")};PENDIENTE";
                var operacion = new Operacion(registroOperacion);

                _operacionPersistencia.RegistrarOperacion(operacion);
                MessageBox.Show("La solicitud de desbloqueo ha sido registrada y está pendiente de autorización.", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 