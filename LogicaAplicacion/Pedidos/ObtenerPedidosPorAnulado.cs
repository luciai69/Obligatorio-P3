using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Pedidos
{
    public class ObtenerPedidosPorAnulado : IObtenerPorBool<PedidoDto>
    {
        IRepositorioPedido _repositorioPedido;

        public ObtenerPedidosPorAnulado(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public IEnumerable<PedidoDto> Ejecutar(bool dato)
        {
            IEnumerable<PedidoDto> pedidosDto = PedidoMapper.ToListaDto(_repositorioPedido.GetByBool(dato));
            return pedidosDto;
        }

    }

}
