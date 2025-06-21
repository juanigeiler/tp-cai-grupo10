using System;
using System.Windows.Forms;
using Datos;
using Datos.Ventas;
using System.Collections.Generic;
using System.Drawing;
using Negocio;

namespace TemplateTPCorto
{
    public partial class FormPrincipal : Form
    {
        private Credencial _credencial;
        private Perfil _perfil;
        private List<Rol> _roles;

        public FormPrincipal(Credencial credencial, Perfil perfil, List<Rol> roles)
        {
            InitializeComponent();
            _credencial = credencial;
            _perfil = perfil;
            _roles = roles;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"Sistema - Usuario: {_credencial.NombreUsuario} - Perfil: {_perfil.Descripcion}";
            lblBienvenida.Text = $"Bienvenido {_credencial.NombreUsuario}";

            // Configurar menú según perfil
            switch (_perfil.Descripcion.ToUpper())
            {
                case "SUPERVISOR":
                    ConfigurarMenuSupervisor();
                    break;
                case "ADMINISTRADOR":
                    ConfigurarMenuAdministrador();
                    break;
                case "OPERADOR":
                    ConfigurarMenuOperador();
                    CargarClientes();
                    break;
            }
        }

        private void ConfigurarMenuSupervisor()
        {
            int buttonY = 20;

            // Verificar cada rol del supervisor
            foreach (Rol rol in _roles)
            {
                Console.WriteLine($"Verificando rol: {rol.Descripcion}");

                switch (rol.Descripcion.ToUpper())
                {
                    case "MODIFICAR PERSONA":
                        AgregarBoton("Modificar Persona", buttonY, BtnModificarPersona_Click);
                        buttonY += 40;
                        break;

                    case "DESBLOQUEAR CREDENCIAL":
                        AgregarBoton("Desbloquear Credencial", buttonY, BtnDesbloquearCredencial_Click);
                        buttonY += 40;
                        break;
                }
            }

            // Agregar botón de cambiar contraseña para supervisor
            AgregarBoton("Cambiar Contraseña", buttonY, BtnCambiarContrasena_Click);
        }

        private void CargarClientes()
        {
            try
            {
                VentasNegocio ventasNegocio = new VentasNegocio();
                var listaClientes = ventasNegocio.obtenerClientes();

                comboClientes.DataSource = listaClientes;
                comboClientes.DisplayMember = "NombreCompleto";
                comboClientes.ValueMember = "Id";
                comboClientes.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void ConfigurarMenuAdministrador()
        {
            AgregarBoton("Autorizaciones", 20, BtnAutorizaciones_Click);
            AgregarBoton("Cambiar Contraseña", 60, BtnCambiarContrasena_Click);
        }

        private void ConfigurarMenuOperador()
        {
            Label lblOperador = new Label
            {
                Text = "Módulo Operador - Fase 2",
                AutoSize = true,
                Location = new Point(10, 20),
                Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold)
            };
            panelMenu.Controls.Add(lblOperador);
            AgregarBoton("Cargar Venta", 60, BtnCargarVenta_Click);
            AgregarBoton("Cambiar Contraseña", 100, BtnCambiarContrasena_Click);
        }

        private void AgregarBoton(string texto, int posicionY, EventHandler clickHandler)
        {
            Button btn = new Button
            {
                Text = texto,
                Size = new Size(180, 35),
                Location = new Point(10, posicionY),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font(this.Font.FontFamily, 10, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat
            };
            
            btn.Click += clickHandler;
            panelMenu.Controls.Add(btn);
        }

        private void BtnModificarPersona_Click(object sender, EventArgs e)
        {
            FormModificarPersona formModificarPersona = new FormModificarPersona();
            formModificarPersona.ShowDialog();
        }

        private void BtnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            FormDesbloquearCredencial formDesbloquear = new FormDesbloquearCredencial();
            formDesbloquear.ShowDialog();
        }

        private void BtnAutorizaciones_Click(object sender, EventArgs e)
        {
            FormAutorizaciones formAutorizaciones = new FormAutorizaciones();
            formAutorizaciones.ShowDialog();
        }

        private void BtnCargarVenta_Click(object sender, EventArgs e)
        {
            if (comboClientes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para iniciar la venta.", "Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente clienteSeleccionado = (Cliente)comboClientes.SelectedItem;

            FormCargarVenta formCargarVenta = new FormCargarVenta(clienteSeleccionado);
            formCargarVenta.ShowDialog();
        }

        private void BtnCambiarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                FormCambiarContrasena formCambiar = new FormCambiarContrasena(_credencial);            
                formCambiar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}