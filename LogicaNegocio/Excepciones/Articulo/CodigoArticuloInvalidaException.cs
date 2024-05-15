using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class CodigoArticuloInvalidaException : ArticuloException
    {
        public CodigoArticuloInvalidaException() : base ("El código debe tener 13 caracteres.")
        {

        }
    }
}
