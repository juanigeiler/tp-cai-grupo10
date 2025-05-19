using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Rol
    {
        private int _idRol;
        private string _descripcion;

        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Rol(string registro)
        {
            string[] datos = registro.Split(';');
            this._idRol = int.Parse(datos[0]);
            this._descripcion = datos[1];
        }
    }
}