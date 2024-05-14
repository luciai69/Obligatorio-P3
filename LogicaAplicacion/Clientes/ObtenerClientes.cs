using LogicaAccesoDatos.EF;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Clientes
{
    public class ObtenerClientes : IObtenerTodos<ClienteDto>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerClientes(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }
        public IEnumerable<ClienteDto> Ejecutar()
        {
            IEnumerable<ClienteDto> clientesDto = ClienteMapper.ToListaDto(_repositorioCliente.GetAll());
            return clientesDto;
        }

    }
}

