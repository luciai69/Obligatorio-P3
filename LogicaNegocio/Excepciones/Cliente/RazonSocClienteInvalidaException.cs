using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class RazonSocClienteInvalidaException : ClienteException
    {
        public RazonSocClienteInvalidaException() : base("La razon social no puede estar vacia.") 
        {
            
        }
    }
}
