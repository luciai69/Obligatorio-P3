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
                throw new PlazoExpressPedidoInvalidaException();
            }
        }
        public override void CalcularRecargo()
        {
            if(FechaRealizado.Date == FechaEntrega.Date)
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * ((double)ParametrosGenerales.RecargoExpressDia / 100));
            }
            else
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * ((double)ParametrosGenerales.RecargoExpress / 100));
            }

            MontoTotal += MontoTotal * ((double)ParametrosGenerales.Iva / 100);
        }
    }
}
