using System;
using System.Windows.Forms;
using Persistencia;
using Datos;

namespace TemplateTPCorto
{
    public partial class FormModificarPersona : Form
    {
        private UsuarioPersistencia _usuarioPersistencia;
        private OperacionPersistencia _operacionPersistencia;
        private string _legajoActual;

        public FormModificarPersona()
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

                // TODO: Implementar búsqueda de persona por legajo
                _legajoActual = txtLegajo.Text;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Registrar la operación
                var operacion = new Operacion
                {
                    IdOperacion = DateTime.Now.Millisecond, // Temporal, debería ser un ID único
                    Legajo = _legajoActual,
                    TipoOperacion = "CAMBIO_PERSONA",
                    Descripcion = $"Modificación de datos: Nombre={txtNombre.Text}, Apellido={txtApellido.Text}",
                    Fecha = DateTime.Now,
                    Estado = "PENDIENTE"
                };

                _operacionPersistencia.RegistrarOperacion(operacion);
                MessageBox.Show("La solicitud de modificación ha sido registrada y está pendiente de autorización.", 
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