using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;


namespace LogicaAplicacion.Articulos
{
    public class AltaArticulo : IAlta<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;

        public AltaArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(Articulo articulo)
        {
            _repositorioArticulo.Add(articulo);
        }
    }
}
