using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulos : IObtenerTodos<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticulos(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<Articulo> Ejecutar()
        {
            return _repositorioArticulo.GetAll();
        }

    }
}
