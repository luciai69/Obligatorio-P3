using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Linea
{
    public class CantLineaInvalidaException : LineaException
    {
        public CantLineaInvalidaException(): base("Ingrese una cantidad valida.") { }
    }
}
