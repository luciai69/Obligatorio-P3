using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Linea
{
    public class ArticuloLineaInvalidaException : LineaException
    {
        public ArticuloLineaInvalidaException() : base("Ingrese un articulo.") { }
    }
}
