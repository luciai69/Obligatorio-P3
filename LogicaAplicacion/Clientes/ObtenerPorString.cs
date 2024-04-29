using LogicaAccesoDatos.EF;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Clientes
{
    public class ObtenerPorString : IObtenerPorString<ClienteDto>
    {
        IRepositorioCliente _repositorioCliente;

        public ObtenerPorString(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public IEnumerable<ClienteDto> Ejecutar(string dato)
        {
            IEnumerable<ClienteDto> clientesDtoPorString = ClienteMapper.ToListaDto(_repositorioCliente.GetByString(dato));

            return clientesDtoPorString;
        }
    }
}
