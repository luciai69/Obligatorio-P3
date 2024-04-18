using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;


namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class AdminMapper
    {
        public static Administrador FromDto(AdminDto adminDto)
        {
            return new Administrador()
            {
                Id = adminDto.Id,
                NombreCompleto = new NombreCompleto(adminDto.Nombre, adminDto.Apellido),
                Mail = adminDto.Mail,
                Contrasenia = adminDto.Contrasenia,
                Discriminator = adminDto.Discriminator,
            };
        }

        public static AdminDto ToDto(Administrador admin)
        {
            return new AdminDto(admin.Id, admin.NombreCompleto.Nombre, admin.NombreCompleto.Apellido, admin.Mail, admin.Contrasenia, admin.Discriminator);
        }

        public static IEnumerable<AdminDto> ToListaDto(IEnumerable<Administrador> admins)
        {
            List<AdminDto> aux = new List<AdminDto>();
            foreach (var admin in admins)
            {
                AdminDto adminDto = AdminMapper.ToDto(admin);
                aux.Add(adminDto);
            }
            return aux;
        }
    }
}
