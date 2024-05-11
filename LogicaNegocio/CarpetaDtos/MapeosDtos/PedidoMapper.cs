using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class PedidoMapper
    {
        public static PedidoDto ToDto(Pedido pedido)
        {
            return new PedidoDto(pedido.Id, pedido.FechaEntrega, pedido.Cliente.RazonSoc, pedido.MontoTotal, pedido.Discriminator);
        }

        public static IEnumerable<PedidoDto> ToListaDto(IEnumerable<Pedido> pedidos)
        {
            List<PedidoDto> aux = new List<PedidoDto>();
            foreach (var pedido in pedidos)
            {
                PedidoDto pedidoDto = PedidoMapper.ToDto(pedido);
                aux.Add(pedidoDto);
            }
            return aux;
        }
    }
}
