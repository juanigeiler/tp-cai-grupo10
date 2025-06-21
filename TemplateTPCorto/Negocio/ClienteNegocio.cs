using Datos.Ventas;
using Persistencia;
using System.Collections.Generic;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ObtenerClientes()
        {
            ClientePersistencia persistencia = new ClientePersistencia();
            return persistencia.obtenerClientes();
        }
    }
}