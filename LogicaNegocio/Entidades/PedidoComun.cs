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
                throw new PlazoComunPedidoInvalidaException();
            }
        }
        public override void CalcularRecargo()
        {
            if(Cliente.Direccion.DistanciaPapeleria > 100)
            {
                MontoTotal = MontoSubtotal + (MontoSubtotal * ((double)ParametrosGenerales.RecargoComunDistancia / 100));
            }else
            {
                MontoTotal = MontoSubtotal;            
            }

            MontoTotal += MontoTotal * ((double)ParametrosGenerales.Iva / 100);
        }
    }
}
