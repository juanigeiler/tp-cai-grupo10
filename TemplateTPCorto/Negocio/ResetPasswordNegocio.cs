using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ResetPasswordNegocio
    {
        private const int DiasExpiracion = 30;

        public bool DebeCambiarContrasena(Credencial credencial)
        {
            return (DateTime.Now - credencial.FechaUltimoLogin).TotalDays > DiasExpiracion;
        }

        public bool CambiarContrasena(Credencial credencial, string nuevaContrasena)
        {
            if (credencial == null)
            {
                Console.WriteLine("Error: La credencial no puede ser nula.");
                return false;
            }

            if (nuevaContrasena == credencial.Contrasena)
            {
                Console.WriteLine("La nueva contraseña no puede ser igual a la anterior.");
                return false;
            }

            if (nuevaContrasena.Length < 8)
            {
                Console.WriteLine(" La contraseña debe tener al menos 8 caracteres.");
                return false;
            }

            credencial.Contrasena = nuevaContrasena;
            credencial.FechaUltimoLogin = DateTime.Now;
            Console.WriteLine("Contraseña cambiada correctamente.");
            return true;
        }
    }
}