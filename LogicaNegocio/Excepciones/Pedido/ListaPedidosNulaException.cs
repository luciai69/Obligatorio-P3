using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class ListaPedidosNulaException : PedidoException
        {
            public ListaPedidosNulaException() : base("No hay pedidos para mostrar.") { }
        }
    }
