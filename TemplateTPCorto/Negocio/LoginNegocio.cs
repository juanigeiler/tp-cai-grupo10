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
        public Credencial login(String usuario, String password)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

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

            if (!credencial.EsPrimerLogin)
            {
                usuarioPersistencia.ActualizarFechaUltimoLogin(legajo, DateTime.Now);
            }

            return credencial;
        }

        public void CambiarPasswordPrimerLogin(string legajo, string nuevaPassword)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            // usuarioPersistencia.ActualizarPassword(legajo, nuevaPassword); 
            usuarioPersistencia.ActualizarFechaUltimoLogin(legajo, DateTime.Now);
        }
    }
}