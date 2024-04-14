using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Contrasenia { get; set; }
        public string Discriminator { get; set; }

        public UsuarioDto(int id, string nombre, string apellido, string mail, string contrasenia, string discriminator)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contrasenia = contrasenia;
            Discriminator = discriminator;
        }



    }


}
