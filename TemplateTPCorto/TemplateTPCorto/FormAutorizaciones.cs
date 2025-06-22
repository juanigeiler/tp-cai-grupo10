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
                    operacion.Fecha,
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
                        operacion.Fecha,
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
            ProcesarOperacion(true);
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            ProcesarOperacion(false);
        }

        private void ProcesarOperacion(bool autorizar)
        {
            try
            {
                if (dgvAutorizaciones.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione una operación para procesar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor ingrese un motivo para la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var operacionSeleccionada = dgvAutorizaciones.SelectedRows[0];
                int idOperacion = Convert.ToInt32(operacionSeleccionada.Cells["IdOperacion"].Value);
                string tipoOperacionCompleto = operacionSeleccionada.Cells["TipoOperacion"].Value.ToString();
                string motivo = txtMotivo.Text;
                string estado = autorizar ? "AUTORIZADO" : "RECHAZADO";

                string tipoOperacionSimple = "";
                string mensajeExito = "";

                if (tipoOperacionCompleto == "CAMBIO_CREDENCIAL")
                {
                    tipoOperacionSimple = "credencial";
                    _operacionPersistencia.ProcesarCambioCredencial(idOperacion, autorizar);
                    mensajeExito = $"Operación de cambio de credencial ha sido procesada como {estado.ToLower()}.";
                }
                else if (tipoOperacionCompleto == "CAMBIO_PERSONA")
                {
                    tipoOperacionSimple = "persona";
                    if (autorizar)
                    {
                        _operacionPersistencia.AutorizarCambioPersona(idOperacion);
                    }
                    else
                    {
                        _operacionPersistencia.RechazarCambioPersona(idOperacion);
                    }
                    mensajeExito = $"Solicitud de cambio de persona ha sido {estado.ToLower()}.";
                }
                else
                {
                    MessageBox.Show("Tipo de operación no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _operacionPersistencia.RegistrarAutorizacion(idOperacion, tipoOperacionSimple, motivo, estado);

                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarOperaciones();
                txtMotivo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 