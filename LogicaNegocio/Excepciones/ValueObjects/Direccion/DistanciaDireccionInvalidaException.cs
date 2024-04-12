using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.Direccion
{
    public class DistanciaDireccionInvalidaException : DireccionException
    {
        public DistanciaDireccionInvalidaException() : base("La distancia a la papeleria no puede ser menor a 0.") { }
    }
}
