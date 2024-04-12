using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class RutClienteInvalidaException : ClienteException
    {
        public RutClienteInvalidaException() : base("El RUT no puede estar vacio.") 
        { }
    }
}
