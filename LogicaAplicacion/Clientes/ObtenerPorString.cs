using LogicaAccesoDatos.EF;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Clientes
{
    public class ObtenerPorString : IObtenerPorString<Cliente>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerPorString(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public IEnumerable<Cliente> Ejecutar(string dato)
        {
            return _repositorioCliente.GetByString(dato);
        }
    }
}
