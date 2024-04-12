using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.Direccion
{
    public class NumDireccionInvalidaException : DireccionException
    {
        public NumDireccionInvalidaException() : base("El numero no puede estar vacio.") { }
    }
}
