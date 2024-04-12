using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuario : IObtener<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuario(IRepositorioUsuario repositotioUsuario) 
        {
            _repositorioUsuario = repositotioUsuario;
        }

        public Usuario Ejecutar(int id)
        {
            return _repositorioUsuario.GetById(id);
        }
    }
}
