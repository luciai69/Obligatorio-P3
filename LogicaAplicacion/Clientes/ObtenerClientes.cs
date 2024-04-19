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
    public class ObtenerClientes : IObtenerTodos<Cliente> //TODO Hay que hacer ClienteDTO
        {
            IRepositorioCliente _repositorioCliente;

            public ObtenerClientes(IRepositorioCliente repositorioCliente)
            {
                _repositorioCliente = repositorioCliente;
            }

            public IEnumerable<Cliente> Ejecutar()
            {
                return _repositorioCliente.GetAll();
            }

    }
}

