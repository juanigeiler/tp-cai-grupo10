using System;

namespace Datos
{
    public class Operacion
    {
        private int _idOperacion;
        private string _legajo;
        private string _tipoOperacion;
        private string _descripcion;
        private DateTime _fecha;
        private string _estado;

        public int IdOperacion { get => _idOperacion; set => _idOperacion = value; }
        public string Legajo { get => _legajo; set => _legajo = value; }
        public string TipoOperacion { get => _tipoOperacion; set => _tipoOperacion = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }

        public Operacion(string registro)
        {
            string[] datos = registro.Split(';');
            this._idOperacion = int.Parse(datos[0]);
            this._legajo = datos[1];
            this._tipoOperacion = datos[2];
            this._descripcion = datos[3];
            this._fecha = DateTime.ParseExact(datos[4], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            this._estado = datos[5];
        }

        public override string ToString()
        {
            return $"{_idOperacion};{_legajo};{_tipoOperacion};{_descripcion};{_fecha.ToString("d/M/yyyy")};{_estado}";
        }
    }
} 