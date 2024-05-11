using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    internal class PlazoComunPedidoInvalidaException : PedidoException
    {
        public PlazoComunPedidoInvalidaException() : base("La fecha de entrega debe ser por lo menos 7 días después de realizado.") { }
    }
}
