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

    public class ObtenerPedidosPorFecha : IObtenerPorFecha<PedidoDto>
    {
        IRepositorioPedido _repositorioPedido;

        public ObtenerPedidosPorFecha(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public IEnumerable<PedidoDto> Ejecutar(DateTime fecha)
        {
            IEnumerable<PedidoDto> pedidosDto = PedidoMapper.ToListaDto(_repositorioPedido.GetByDate(fecha));
            return pedidosDto;
        }

    }
    
}
