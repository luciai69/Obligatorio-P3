using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class EliminarUsuario : IEliminar<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;

        public EliminarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id)
        {
            _repositorioUsuario.Delete(id);
        }
    }
}
