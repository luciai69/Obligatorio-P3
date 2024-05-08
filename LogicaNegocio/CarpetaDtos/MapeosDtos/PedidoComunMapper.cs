using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    internal class PedidoComunMapper
    {
        public static PedidoComun FromDto(PedidoComun pedidoComunDto)
        {
            return new PedidoComun()
            {
                Id = pedidoComunDto.Id,
                FechaRealizado = pedidoComunDto.FechaRealizado,
                ClienteId = pedidoComunDto.ClienteId,
                FechaEntrega = pedidoComunDto.FechaEntrega,
                MontoSubtotal = pedidoComunDto.MontoSubtotal,
                Cantidad = pedidoComunDto.Cantidad,
                Discriminator = pedidoComunDto.Discriminator,
                Lineas = LineaMapper.FromListaDto(pedidoComunDto.Lineas),
            };
        }

        public static PedidoComunDto ToDto(PedidoComun pedidoComun)
        {
            return new PedidoComunDto(pedidoComun.Id, pedidoComun.FechaRealizado, pedidoComun.ClienteId, pedidoComun.FechaEntrega, pedidoComun.MontoSubtotal, pedidoComun.Cantidad, pedidoComun.Discriminator);
        }

        public static IEnumerable<PedidoComunDto> ToListaDto(IEnumerable<PedidoComun> pedidos)
        {
            List<PedidoComunDto> aux = new List<PedidoComunDto>();
            foreach (var pedidoComun in pedidos)
            {
                PedidoComunDto pedidoComunDto = PedidoComunMapper.ToDto(pedidoComun);
                aux.Add(pedidoComunDto);
            }
            return aux;
        }
    }
}
