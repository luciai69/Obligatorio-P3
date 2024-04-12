using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class EliminarArticulo : IEliminar<Articulo> // NO ES NECESARIO
    {
        IRepositorioArticulo _repositorioArticulo;

        public EliminarArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id)
        {
            _repositorioArticulo.Delete(id);
        }

    }
}
