using System;

namespace Datos
{
    public class Operacion
    {
        private int _idOperacion;
        private string _legajo;
        private string _tipoOperacion;
        private string _descripcion;
        private string _fecha;
        private string _estado;

        public int IdOperacion { get => _idOperacion; set => _idOperacion = value; }
        public string Legajo { get => _legajo; set => _legajo = value; }
        public string TipoOperacion { get => _tipoOperacion; set => _tipoOperacion = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }

        public Operacion()
        {
        }

        public override string ToString()
        {
            return $"{_idOperacion};{_legajo};{_tipoOperacion};{_descripcion};{_fecha};{_estado}";
        }
    }
}
