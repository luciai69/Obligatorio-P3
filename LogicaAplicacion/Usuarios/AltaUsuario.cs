using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;

namespace LogicaAplicacion.Usuarios
{
    public class AltaUsuario : IAlta<AdminDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar (AdminDto adminDto)
        {
            Administrador admin = AdminMapper.FromDto(adminDto);
            _repositorioUsuario.Add(admin);
        }
    }
}
