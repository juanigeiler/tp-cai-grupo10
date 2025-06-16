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

        public FormModificarPersona()
        {
            InitializeComponent();
            _usuarioPersistencia = new UsuarioPersistencia();
            _operacionPersistencia = new OperacionPersistencia();
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
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
                        
                        txtNombre.Text = _nombreActual;
                        txtApellido.Text = _apellidoActual;
                        
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
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
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
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
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Leer el archivo de operaciones para calcular el próximo idOperacion
                string rutaOperacion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas\operacion_cambio_persona.csv");
                int nuevoId = 1;
                if (File.Exists(rutaOperacion))
                {
                    var lineas = File.ReadAllLines(rutaOperacion);
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        var campos = lineas[i].Split(';');
                        if (int.TryParse(campos[0], out int id))
                        {
                            if (id >= nuevoId) nuevoId = id + 1;
                        }
                    }
                }

                // Buscar los datos actuales de la persona para dni y fecha_ingreso
                string rutaPersona = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas\persona.csv");
                string dni = "";
                string fechaIngreso = "";
                if (File.Exists(rutaPersona))
                {
                    var lineas = File.ReadAllLines(rutaPersona);
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        var campos = lineas[i].Split(';');
                        if (campos[0] == _legajoActual)
                        {
                            dni = campos[3];
                            fechaIngreso = campos[4];
                            break;
                        }
                    }
                }

                // Formato: idOperacion;legajo;nombre;apellido;dni;fecha_ingreso
                string registroOperacion = $"{nuevoId};{_legajoActual};{txtNombre.Text};{txtApellido.Text};{dni};{fechaIngreso}";
                bool agregarSalto = false;
                if (File.Exists(rutaOperacion))
                {
                    var info = new FileInfo(rutaOperacion);
                    if (info.Length > 0)
                    {
                        using (var fs = new FileStream(rutaOperacion, FileMode.Open, FileAccess.Read))
                        {
                            fs.Seek(-1, SeekOrigin.End);
                            int lastByte = fs.ReadByte();
                            agregarSalto = lastByte != '\n' && lastByte != '\r';
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(rutaOperacion, true))
                {
                    if (agregarSalto) sw.WriteLine();
                    sw.WriteLine(registroOperacion);
                }

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