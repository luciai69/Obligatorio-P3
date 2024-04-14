using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Linea
{
    public class LineaException : DomainException
    {
        public LineaException() { }
        public LineaException(string message) : base(message) { }
    }
}
