using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();

            if (FechaEntrega > FechaRealizado.AddDays(ParametrosGenerales.Plazo))
            {
                throw new FechaRealizadoPedidoInvalidaException();
            }
        }
        public override void CalcularRecargo()
        {
            if(FechaRealizado.Date == FechaEntrega.Date)
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * 0.15);
            }
            else
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * 0.1);
            }

            MontoTotal = MontoTotal + (MontoTotal * (ParametrosGenerales.Iva/100));
        }
    }
}
