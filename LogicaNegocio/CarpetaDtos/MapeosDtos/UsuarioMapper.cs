using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;


namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class UsuarioMapper
    {
        public static Usuario FromDto(UsuarioDto usuarioDto)
        {
            return new Usuario()
            {
                Id = usuarioDto.Id,
                NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido),
                Mail = usuarioDto.Mail,
                Contrasenia = usuarioDto.Contrasenia,
                Discriminator = usuarioDto.Discriminator,
            };
        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto(usuario.Id, usuario.NombreCompleto.Nombre, usuario.NombreCompleto.Apellido, usuario.Mail, usuario.Contrasenia, usuario.Discriminator);
        }

        public static IEnumerable<UsuarioDto> ToListaDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDto> aux = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                UsuarioDto usuarioDto = UsuarioMapper.ToDto(usuario);
                aux.Add(usuarioDto);
            }
            return aux;
        }
    }
}
