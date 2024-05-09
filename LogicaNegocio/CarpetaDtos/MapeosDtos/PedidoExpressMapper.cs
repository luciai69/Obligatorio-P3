using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class PedidoExpressMapper
    {
        public static PedidoExpress FromDto(PedidoExpressDto pedidoExpressDto)
        {
            return new PedidoExpress()
            {
                Id = pedidoExpressDto.Id,
                FechaRealizado = pedidoExpressDto.FechaRealizado,
                ClienteId = pedidoExpressDto.ClienteId,
                FechaEntrega = pedidoExpressDto.FechaEntrega,
                MontoSubtotal = pedidoExpressDto.MontoSubtotal,
                Cantidad = pedidoExpressDto.Cantidad,
                Discriminator = pedidoExpressDto.Discriminator,
                Lineas = LineaMapper.FromListaDto(pedidoExpressDto.Lineas),
            };
        }

        public static PedidoExpressDto ToDto(PedidoExpress pedidoExpress)
        {
            return new PedidoExpressDto(pedidoExpress.Id, pedidoExpress.FechaRealizado, pedidoExpress.ClienteId, pedidoExpress.FechaEntrega, pedidoExpress.MontoSubtotal, pedidoExpress.Cantidad, pedidoExpress.Discriminator);
        }

        public static IEnumerable<PedidoExpressDto> ToListaDto(IEnumerable<PedidoExpress> pedidos)
        {
            List<PedidoExpressDto> aux = new List<PedidoExpressDto>();
            foreach (var pedidoExpress in pedidos)
            {
                PedidoExpressDto pedidoExpressDto = PedidoExpressMapper.ToDto(pedidoExpress);
                aux.Add(pedidoExpressDto);
            }
            return aux;
        }
    }
}
