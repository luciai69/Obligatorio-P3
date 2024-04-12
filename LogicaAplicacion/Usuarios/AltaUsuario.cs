using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;

namespace LogicaAplicacion.Usuarios
{
    public class AltaUsuario : IAlta<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar (Usuario usuario)
        {
            _repositorioUsuario.Add(usuario);
        }
    }
}
