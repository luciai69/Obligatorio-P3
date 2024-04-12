using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class DescripcionArticuloInvalidaException : ArticuloException
    {
        public DescripcionArticuloInvalidaException() : base("La descripción tiene que ser mayor a 5 caracteres.") 
        { 
        
        }
    }
}
