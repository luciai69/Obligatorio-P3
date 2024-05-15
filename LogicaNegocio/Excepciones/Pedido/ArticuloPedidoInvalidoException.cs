﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class ArticuloPedidoInvalidoException : PedidoException
    {
        public ArticuloPedidoInvalidoException() : base("Seleccione un artículo.") { }
    }
}
