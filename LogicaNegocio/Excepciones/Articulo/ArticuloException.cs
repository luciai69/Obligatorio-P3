﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class ArticuloException : DomainException
    {
        public ArticuloException() { }
        public ArticuloException(string message) : base(message) { }
    }
}
