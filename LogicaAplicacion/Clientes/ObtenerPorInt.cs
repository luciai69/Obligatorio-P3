using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Clientes
{
    public class ObtenerPorInt : IObtenerPorInt<ClienteDto>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerPorInt(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public IEnumerable<ClienteDto> Ejecutar(int dato)
        {
            IEnumerable<ClienteDto> clientesDtoPorInt = ClienteMapper.ToListaDto(_repositorioCliente.GetByMonto(dato));

            return clientesDtoPorInt;
        }
    }
}
