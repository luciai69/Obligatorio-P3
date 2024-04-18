using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record AdminDto(int Id, string Nombre, string Apellido, string Mail, string Contrasenia, string Discriminator)
    {

    }
}
