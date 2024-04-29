using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuario : IObtener<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuario(IRepositorioUsuario repositotioUsuario) 
        {
            _repositorioUsuario = repositotioUsuario;
        }

        public UsuarioDto Ejecutar(int id)
        {
            UsuarioDto usuarioDto = UsuarioMapper.ToDto(_repositorioUsuario.GetById(id));
            return usuarioDto;
        }
    }
}
