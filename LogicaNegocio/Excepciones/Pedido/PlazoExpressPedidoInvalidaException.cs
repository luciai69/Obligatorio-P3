using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    internal class PlazoExpressPedidoInvalidaException : PedidoException
    {
        public PlazoExpressPedidoInvalidaException() : base($"La fecha de entrega no puede superar los {ParametrosGenerales.Plazo} días.") { }
    }
}
