using System;

namespace Datos
{
    public class Perfil
    {
        private int _idPerfil;
        private string _descripcion;

        public int IdPerfil { get => _idPerfil; set => _idPerfil = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Perfil(string registro)
        {
            string[] datos = registro.Split(';');
            this._idPerfil = int.Parse(datos[0]);
            this._descripcion = datos[1];
        }
    }
}