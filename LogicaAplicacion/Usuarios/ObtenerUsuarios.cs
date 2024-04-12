using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuarios : IObtenerTodos<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<Usuario> Ejecutar()
        {
            return _repositorioUsuario.GetAll();
        }
    }
}
