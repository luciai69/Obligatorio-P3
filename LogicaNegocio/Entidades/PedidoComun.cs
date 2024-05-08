using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();

            if(FechaEntrega < FechaRealizado.AddDays(7))
            {
                throw new FechaRealizadoPedidoInvalidaException();
            }
        }
        public override void CalcularRecargo()
        {
            if(Cliente.Direccion.DistanciaPapeleria > 100)
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * 0.05);
            }
        }
    }
}
