using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class PedidoNuloException : PedidoException
    {
        public PedidoNuloException(): base("No se pudo recuperar el pedido.") { }
    }
}
