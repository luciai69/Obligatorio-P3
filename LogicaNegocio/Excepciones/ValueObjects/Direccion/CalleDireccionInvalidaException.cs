using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.Direccion
{
    public class CalleDireccionInvalidaException : DireccionException
    {
        public CalleDireccionInvalidaException() : base("La calle no puede estar vacia.") { }
    }
}
