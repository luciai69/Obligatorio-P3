using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.CarpetaDtos.MapeosDtos;
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
    public class AltaPedidoExpress : IAlta<PedidoExpressDto>
    {
        IRepositorioPedido _repositorioPedido;

        public AltaPedidoExpress(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void Ejecutar(PedidoExpressDto pedidoExpressDto)
        {
            PedidoExpress pedidoExpress = PedidoExpressMapper.FromDto(pedidoExpressDto);
            _repositorioPedido.Add(pedidoExpress);
        }
    }
}
