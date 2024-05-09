using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido : IEntity, IValidable
    {
        public int Id { get; set; }
        public DateTime FechaRealizado { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public List<Linea> Lineas { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double MontoSubtotal { get; set; }
        public double MontoTotal { get; set; }
        public int Cantidad { get; set; }
        public bool Anulado { get; set; } = false;
        public string Discriminator { get; set; }


        public void Validar()
        {
            ValidarFechaRealizado();
            ValidarFechaEntrega();
            ValidarLinea();
            ValidarCliente();
            CalcularRecargo();
        }

        private void ValidarFechaRealizado() 
        {
            FechaRealizado = DateTime.Now;
        }

        public virtual void ValidarFechaEntrega()
        {
            if (FechaEntrega < FechaRealizado) 
            {
                throw new FechaRecibidoPedidoInvalidaException();
            }
        }

        private void ValidarLinea() 
        {
            if (Lineas.Count == 0) 
            {
                throw new LineaPedidoInvalidaException();
            }
        }

        private void ValidarCliente() 
        {
            if (ClienteId <= 0) 
            {
                throw new ClientePedidoInvalidaException();
            }
        }

        //public void CaluclarSubtotal()
        //{
        //    double subtotal = 0;

        //    foreach(Linea linea in Lineas)
        //    {
        //        subtotal += linea.CalcularPrecio();
        //    }

        //    MontoSubtotal = subtotal;
        //}

        public abstract void CalcularRecargo();
        
    }
}
