using LogicaNegocio.Excepciones.ValueObjects.NombreCompleto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (string.IsNullOrEmpty(Nombre))
            { 
                throw new NombreNombreCompletoInvalidaException();
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new ApellidoNombreCompletoInvalidaException();
            }

        }
    }
}
