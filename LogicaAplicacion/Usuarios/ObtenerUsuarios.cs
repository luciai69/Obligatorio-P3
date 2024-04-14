using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuarios : IObtenerTodos<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<UsuarioDto> Ejecutar()
        {
            IEnumerable<UsuarioDto> usuariosDto = UsuarioMappers.ToListaDto(_repositorioUsuario.GetAll());
            return usuariosDto;
        }
    }
}
