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
            this.BackColor = Color.FromArgb(240, 240, 240); // Un gris claro para el fondo
            panelMenu.BackColor = Color.FromArgb(45, 62, 80); // Un azul oscuro para el menú
            
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(45, 62, 80);
            
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
            // Ocultar panel de venta para supervisor
            panelVenta.Visible = false;
            
            // Crear panel central para botones administrativos
            Panel panelAdmin = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(400, 300),
                Location = new Point((panelContenido.Width - 400) / 2, (panelContenido.Height - 300) / 2)
            };
            panelContenido.Controls.Add(panelAdmin);

            // Título del panel
            Label lblTituloAdmin = new Label
            {
                Text = "PANEL DE SUPERVISIÓN",
                AutoSize = false,
                Size = new Size(380, 40),
                Location = new Point(10, 20),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 62, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelAdmin.Controls.Add(lblTituloAdmin);

            int buttonY = 80;

            // Verificar cada rol del supervisor
            foreach (Rol rol in _roles)
            {
                Console.WriteLine($"Verificando rol: {rol.Descripcion}");

                switch (rol.Descripcion.ToUpper())
                {
                    case "MODIFICAR PERSONA":
                        AgregarBotonCentrado("Modificar Persona", buttonY, BtnModificarPersona_Click, panelAdmin);
                        buttonY += 50;
                        break;

                    case "DESBLOQUEAR CREDENCIAL":
                        AgregarBotonCentrado("Desbloquear Credencial", buttonY, BtnDesbloquearCredencial_Click, panelAdmin);
                        buttonY += 50;
                        break;
                }
            }

            // Agregar botón de cambiar contraseña para supervisor
            AgregarBotonCentrado("Cambiar Contraseña", buttonY, BtnCambiarContrasena_Click, panelAdmin);
        }

        private void ConfigurarMenuAdministrador()
        {
            // Ocultar panel de venta para administrador
            panelVenta.Visible = false;
            
            // Crear panel central para botones administrativos
            Panel panelAdmin = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(400, 200),
                Location = new Point((panelContenido.Width - 400) / 2, (panelContenido.Height - 200) / 2)
            };
            panelContenido.Controls.Add(panelAdmin);

            // Título del panel
            Label lblTituloAdmin = new Label
            {
                Text = "PANEL DE ADMINISTRACIÓN",
                AutoSize = false,
                Size = new Size(380, 40),
                Location = new Point(10, 20),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 62, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelAdmin.Controls.Add(lblTituloAdmin);

            AgregarBotonCentrado("Autorizaciones", 80, BtnAutorizaciones_Click, panelAdmin);
            AgregarBotonCentrado("Cambiar Contraseña", 130, BtnCambiarContrasena_Click, panelAdmin);
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

        private void ConfigurarMenuOperador()
        {
            Label lblModuloTitulo = new Label
            {
                Text = "MÓDULO DE VENTAS",
                AutoSize = false,
                Size = new Size(180, 40),
                Location = new Point(10, 20),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelMenu.Controls.Add(lblModuloTitulo);
            AgregarBoton("Cargar Venta", 70, BtnCargarVenta_Click);
            AgregarBoton("Cambiar Contraseña", 120, BtnCambiarContrasena_Click);
        }

        private void AgregarBoton(string texto, int posicionY, EventHandler clickHandler)
        {
            Button btn = new Button
            {
                Text = texto,
                Size = new Size(180, 40),
                Location = new Point(10, posicionY),
                BackColor = Color.FromArgb(52, 152, 219), 
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            
            btn.Click += clickHandler;
            panelMenu.Controls.Add(btn);
        }

        private void AgregarBotonCentrado(string texto, int posicionY, EventHandler clickHandler, Panel panel)
        {
            Button btn = new Button
            {
                Text = texto,
                Size = new Size(200, 40),
                Location = new Point((panel.Width - 200) / 2, posicionY),
                BackColor = Color.FromArgb(52, 152, 219), 
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            
            btn.Click += clickHandler;
            panel.Controls.Add(btn);
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