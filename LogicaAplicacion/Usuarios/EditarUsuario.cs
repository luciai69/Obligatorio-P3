using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class EditarUsuario : IEditar<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public EditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id, UsuarioDto obj)
        {
            Usuario usuario = UsuarioMappers.FromDto(obj);

            _repositorioUsuario.Update(id, usuario);
        }
    }
}
