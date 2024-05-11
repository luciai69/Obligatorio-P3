using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.EF;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.Clientes
{
    public class ObtenerCliente : IObtener<Cliente>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }
        public Cliente Ejecutar(int id)
        {
            return _repositorioCliente.GetById(id);
        }

    }
}
