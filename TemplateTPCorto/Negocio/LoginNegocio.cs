using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LoginNegocio
    {

        public class ResultadoLogin
        {
            public Credencial Credencial { get; set; }
            public Perfil Perfil { get; set; }
            public List<Rol> Roles { get; set; }
        }

        public ResultadoLogin login(String usuario, String password, out bool requiereCambio)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            PerfilPersistencia perfilPersistencia = new PerfilPersistencia();
            requiereCambio = false;

            Credencial credencial = usuarioPersistencia.ObtenerCredencialPorNombreUsuario(usuario);

            if (credencial == null)
            {
                throw new Exception("Credenciales incorrectas.");
            }

            string legajo = credencial.Legajo;

            if (usuarioPersistencia.EstaBloqueado(legajo))
            {
                throw new Exception("El usuario está bloqueado ya que superó el límite de intentos.");
            }

            if (credencial.Contrasena != password)
            {
                if (usuarioPersistencia.CantidadIntentosUsuario(legajo) >= 2)
                {
                    usuarioPersistencia.BloquearUsuario(legajo);
                    throw new Exception("El usuario fue bloqueado por exceder los intentos de login.");
                }

                usuarioPersistencia.RegistrarIntentoFallido(legajo);
                throw new Exception("Credenciales incorrectas.");
            }

            usuarioPersistencia.LimpiarIntentosFallidos(legajo);

            // Verificar si necesita cambiar la contraseña
            if (!credencial.EsPrimerLogin)
            {
                ResetPasswordNegocio reset = new ResetPasswordNegocio();
                if (reset.DebeCambiarContrasena(credencial))
                {
                    requiereCambio = true;
                }
                else
                {
                    usuarioPersistencia.ActualizarFechaUltimoLogin(legajo, DateTime.Now);
                }
            }

            // Obtener perfil y roles
            Perfil perfil = perfilPersistencia.ObtenerPerfilUsuario(credencial.Legajo);
            if (perfil == null)
            {
                throw new Exception("El usuario no tiene un perfil asignado.");
            }

            List<Rol> roles = perfilPersistencia.ObtenerRolesPerfil(perfil.IdPerfil);

            var resultado = new ResultadoLogin 
            { 
                Credencial = credencial,
                Perfil = perfil,
                Roles = roles
            };

            return resultado;
        }

        public void CambiarPasswordPrimerLogin(string legajo, string nuevaPassword)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            //usuarioPersistencia.ActualizarPassword(legajo, nuevaPassword); 
            usuarioPersistencia.ActualizarFechaUltimoLogin(legajo, DateTime.Now);
        }
    }
}