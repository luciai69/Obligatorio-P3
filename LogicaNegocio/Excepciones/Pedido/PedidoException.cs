﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class PedidoException : DomainException
    {
        public PedidoException
            () { }
        public PedidoException(string message) : base(message) { }
    }
}
