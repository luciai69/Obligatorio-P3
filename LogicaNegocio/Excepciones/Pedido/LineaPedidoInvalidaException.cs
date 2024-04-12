using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class LineaPedidoInvalidaException : PedidoException
    {
        public LineaPedidoInvalidaException() : base("Agregue un articulo.") 
        {

        }
    }
}
