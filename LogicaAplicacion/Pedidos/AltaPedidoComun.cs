using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Pedidos
{
    public class AltaPedidoComun : IAlta<PedidoComunDto>
    {
        IRepositorioPedido _repositorioPedido;

        public AltaPedidoComun(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void Ejecutar(PedidoComunDto pedidoComunDto)
        {
            PedidoComun pedidoComun = PedidoComunMapper.FromDto(pedidoComunDto);
            _repositorioPedido.Add(pedidoComun);
        }
    }
}
