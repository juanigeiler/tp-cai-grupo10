using System;
using System.Windows.Forms;
using System.Linq;
using Persistencia;
using Datos;

namespace TemplateTPCorto
{
    public partial class FormAutorizaciones : Form
    {
        private OperacionPersistencia _operacionPersistencia;
        private UsuarioPersistencia _usuarioPersistencia;

        public FormAutorizaciones()
        {
            InitializeComponent();
            _operacionPersistencia = new OperacionPersistencia();
            _usuarioPersistencia = new UsuarioPersistencia();
            ConfigurarGrid();
            CargarOperaciones();
        }

        private void ConfigurarGrid()
        {
            dgvAutorizaciones.Columns.Add("IdOperacion", "ID");
            dgvAutorizaciones.Columns.Add("Legajo", "Legajo");
            dgvAutorizaciones.Columns.Add("TipoOperacion", "Tipo");
            dgvAutorizaciones.Columns.Add("Descripcion", "Descripción");
            dgvAutorizaciones.Columns.Add("Fecha", "Fecha");
            dgvAutorizaciones.Columns.Add("Estado", "Estado");

            dgvAutorizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutorizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutorizaciones.MultiSelect = false;
        }

        private void CargarOperaciones()
        {
            dgvAutorizaciones.Rows.Clear();
            var operaciones = _operacionPersistencia.ObtenerOperaciones();

            foreach (var operacion in operaciones)
            {
                dgvAutorizaciones.Rows.Add(
                    operacion.IdOperacion,
                    operacion.Legajo,
                    operacion.TipoOperacion,
                    operacion.Descripcion,
                    operacion.Fecha.ToString("d/M/yyyy"),
                    operacion.Estado
                );
            }
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

                dgvAutorizaciones.Rows.Clear();
                var operaciones = _operacionPersistencia.ObtenerOperaciones()
                    .Where(o => o.Legajo == txtLegajo.Text);

                foreach (var operacion in operaciones)
                {
                    dgvAutorizaciones.Rows.Add(
                        operacion.IdOperacion,
                        operacion.Legajo,
                        operacion.TipoOperacion,
                        operacion.Descripcion,
                        operacion.Fecha.ToString("d/M/yyyy"),
                        operacion.Estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAutorizaciones.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione una operación para autorizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var operacionSeleccionada = dgvAutorizaciones.SelectedRows[0];
                int idOperacion = Convert.ToInt32(operacionSeleccionada.Cells["IdOperacion"].Value);
                string tipoOperacion = operacionSeleccionada.Cells["TipoOperacion"].Value.ToString();
                string legajo = operacionSeleccionada.Cells["Legajo"].Value.ToString();

                if (string.IsNullOrEmpty(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor ingrese un motivo para la autorización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizar estado de la operación
                _operacionPersistencia.ActualizarEstadoOperacion(idOperacion, "AUTORIZADO");

                // Ejecutar la operación según su tipo
                if (tipoOperacion == "CAMBIO_CREDENCIAL")
                {
                    // TODO: Implementar lógica de cambio de credencial
                    // La contraseña debe registrarse con fecha último login vacía
                }
                else if (tipoOperacion == "CAMBIO_PERSONA")
                {
                    // TODO: Implementar lógica de cambio de persona
                }

                MessageBox.Show("Operación autorizada y ejecutada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOperaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 