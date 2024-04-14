using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;

namespace LogicaAplicacion.Usuarios
{
    public class AltaUsuario : IAlta<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar (UsuarioDto usuarioDto)
        {
            Usuario usuario = UsuarioMappers.FromDto(usuarioDto);
            _repositorioUsuario.Add(usuario);
        }
    }
}
