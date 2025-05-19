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
        public Credencial login(string usuario, string password, out bool requiereCambio)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Credencial credencial = usuarioPersistencia.login(usuario);

            requiereCambio = false;

            if (credencial != null && credencial.Contrasena.Equals(password))
            {
                ResetPasswordNegocio reset = new ResetPasswordNegocio();

                if (reset.DebeCambiarContrasena(credencial))
                {
                    requiereCambio = true;
                }

                return credencial;
            }

            return null;
        }
    }
}
