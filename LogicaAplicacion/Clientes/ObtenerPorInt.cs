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
    public class ObtenerPorInt : IObtenerPorInt<Cliente>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerPorInt(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public IEnumerable<Cliente> Ejecutar(int dato)
        {
            return _repositorioCliente.GetByMonto(dato);
        }
    }
}
