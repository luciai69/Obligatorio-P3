using LogicaAccesoDatos.EF;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulos : IObtenerTodos<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticulos(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<ArticuloDto> Ejecutar()
        {
            IEnumerable<ArticuloDto> articulosDtos = ArticuloMapper.ToListaDto(_repositorioArticulo.GetAll());
            return articulosDtos;
        }

    }
}
