using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class UsuarioMappers
    {
        public static Usuario FromDto(UsuarioDto usuarioDto)
        {
            return new Usuario()
            {
                NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido),
                Mail = usuarioDto.Mail,
                Contrasenia = usuarioDto.Contrasenia,
     
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
                UsuarioDto usuarioDto = UsuarioMappers.ToDto(usuario);
                aux.Add(usuarioDto);
            }
            return aux;
        }
    }
}
