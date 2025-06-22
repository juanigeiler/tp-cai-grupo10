using System;
using System.Windows.Forms;
using Persistencia;
using Datos;
using System.IO;
using System.Linq;

namespace TemplateTPCorto
{
    public partial class FormModificarPersona : Form
    {
        private UsuarioPersistencia _usuarioPersistencia;
        private OperacionPersistencia _operacionPersistencia;
        private string _legajoActual;
        private string _nombreActual;
        private string _apellidoActual;
        private string _dniActual;

        public FormModificarPersona()
        {
            InitializeComponent();
            _usuarioPersistencia = new UsuarioPersistencia();
            _operacionPersistencia = new OperacionPersistencia();
            btnGuardar.Enabled = false;
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

                // Buscar la persona en persona.csv
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas\persona.csv");
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("Error: No se encontró el archivo de personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] lineas = File.ReadAllLines(rutaArchivo);
                bool personaEncontrada = false;

                for (int i = 1; i < lineas.Length; i++) // Empezar desde 1 para saltar el encabezado
                {
                    string[] datos = lineas[i].Split(';');
                    if (datos[0] == txtLegajo.Text)
                    {
                        _legajoActual = datos[0];
                        _nombreActual = datos[1];
                        _apellidoActual = datos[2];
                        _dniActual = datos[3];
                        
                        txtNombre.Text = _nombreActual;
                        txtApellido.Text = _apellidoActual;
                        txtDni.Text = _dniActual;
                        
                        panelDatos.Enabled = true;
                        btnGuardar.Enabled = true;
                        
                        personaEncontrada = true;
                        break;
                    }
                }

                if (!personaEncontrada)
                {
                    MessageBox.Show("No se encontró ninguna persona con ese legajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtDni.Text = "";
                    panelDatos.Enabled = false;
                    btnGuardar.Enabled = false;
                }
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
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Obtener FechaIngreso actual de la persona
                string rutaPersona = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas\persona.csv");
                string fechaIngreso = "";
                if (File.Exists(rutaPersona))
                {
                    var lineas = File.ReadAllLines(rutaPersona);
                    var personaLine = lineas.FirstOrDefault(line => line.Split(';')[0] == _legajoActual);
                    if (personaLine != null)
                    {
                        fechaIngreso = personaLine.Split(';')[4];
                    }
                }

                // 2. Gestionar la operación en el archivo de pendientes
                string rutaOperacion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_persona.csv");
                var lineasOperacion = File.ReadAllLines(rutaOperacion).ToList();
                
                string header = lineasOperacion.Count > 0 ? lineasOperacion[0] : "idOperacion;legajo;nombre;apellido;dni;fecha_ingreso";
                if (lineasOperacion.Count > 0)
                {
                    lineasOperacion.RemoveAt(0);
                }
                
                // Remover cualquier solicitud pendiente anterior para el mismo legajo
                lineasOperacion.RemoveAll(line => line.Split(';')[1] == _legajoActual);
                
                // Crear el nuevo registro de operación
                int nuevoId = _operacionPersistencia.ObtenerSiguienteId();
                string registroOperacion = $"{nuevoId};{_legajoActual};{txtNombre.Text};{txtApellido.Text};{txtDni.Text};{fechaIngreso}";
                lineasOperacion.Add(registroOperacion);
                
                lineasOperacion.Insert(0, header);
                File.WriteAllLines(rutaOperacion, lineasOperacion);

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