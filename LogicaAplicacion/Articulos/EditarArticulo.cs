using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class EditarArticulo : IEditar<Articulo> //NO ES NECESARIO
    {
        IRepositorioArticulo _repositorioArticulo;

        public EditarArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id, Articulo obj)
        {
            _repositorioArticulo.Update(id, obj);
        }
    }
}
