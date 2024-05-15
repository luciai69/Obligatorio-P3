using LogicaNegocio.Excepciones.ValueObjects.NombreCompleto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public record NombreCompleto
    {
        public string Nombre { get; }
        public string Apellido { get; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            Validar();
        }
        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
        }

        private void ValidarNombre()
        {
            var valNombre = new Regex(@"^(?!.*(?: |\-|'))[a-zA-Z][a-zA-Z '-]*[a-zA-Z]$"); //PROMPT GPT: Create a regular expression to validate a string: it can only have letters, lowercase or capital case, and it can include a space, a hyphen or an apostrophe but the space, hyphen or apostrophe cannot be at start or end of the string.
            if (string.IsNullOrEmpty(Nombre) || !valNombre.IsMatch(Nombre))
            { 
                throw new NombreNombreCompletoInvalidaException();
            }
        }

        private void ValidarApellido()
        {
            var valNombre = new Regex(@"^(?!.*(?: |\-|'))[a-zA-Z][a-zA-Z '-]*[a-zA-Z]$");//PROMPT GPT: Create a regular expression to validate a string: it can only have letters, lowercase or capital case, and it can include a space or a hyphen but the space or hyphen cannot be at start or end of the string.
            if (string.IsNullOrEmpty(Apellido) || !valNombre.IsMatch(Apellido))
            {
                throw new ApellidoNombreCompletoInvalidaException();
            }

        }
    }
}
