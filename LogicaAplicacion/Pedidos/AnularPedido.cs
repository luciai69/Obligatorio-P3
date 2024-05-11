using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Pedidos
{
    public class AnularPedido : IAnular<Pedido>
    {
        IRepositorioPedido _repositorioPedido;

        public AnularPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void Ejecutar(int id)
        {
            _repositorioPedido.Anular(id);
        }
    }
}
