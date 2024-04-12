using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.Direccion
{
    public class CiudadDireccionInvalidaException : DireccionException
    {
        public CiudadDireccionInvalidaException() : base("La ciudad no puede estar vacia.") { }
    }
}
