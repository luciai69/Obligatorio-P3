using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class ClientePedidoInvalidaException : PedidoException
    {
        public ClientePedidoInvalidaException() : base ("INGRESE UN CLIENTE.") { }
    }
}
