using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaAccesoDatos.EF;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;


namespace LogicaAplicacion.Articulos
{
    public class AltaArticulo : IAlta<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public AltaArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(ArticuloDto articuloDto)
        {
            Articulo art = ArticuloMapper.FromDto(articuloDto);
            _repositorioArticulo.Add(art); ;
        }
    }
}
