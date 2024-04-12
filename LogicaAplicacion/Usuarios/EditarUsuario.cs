using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class EditarUsuario : IEditar<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;

        public EditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id, Usuario obj)
        {
            _repositorioUsuario.Update(id, obj);
        }
    }
}
