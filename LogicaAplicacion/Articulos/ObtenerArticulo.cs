using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulo : IObtener<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public Articulo Ejecutar(int id)
        {
            return _repositorioArticulo.GetById(id);
        }
    }
}
