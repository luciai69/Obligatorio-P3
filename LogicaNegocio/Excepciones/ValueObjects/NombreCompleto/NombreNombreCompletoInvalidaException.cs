using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.NombreCompleto
{
    internal class NombreNombreCompletoInvalidaException : NombreCompletoException
    {
        public NombreNombreCompletoInvalidaException() : base("Ingrese un nombre valido.") { }
    }
}
