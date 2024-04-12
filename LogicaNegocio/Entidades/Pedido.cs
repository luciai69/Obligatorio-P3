using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Pedido : IEntity, IValidable
    {
        public int Id { get; set; }
        public DateTime FechaRealizado { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public DateTime FechaRecibido { get; set; }
        public bool Anulado { get; set; } = false;
        public double Recargo { get; set; }

        public void Validar()
        {
            ValidarFechaRealizado();
            ValidarFechaRecibido();
            ValidarRecargo();
            ValidarLinea();
            ValidarCliente();
        }

        private void ValidarFechaRealizado() 
        {
            if (FechaRealizado > DateTime.Now) 
            {
                throw new FechaRealizadoPedidoInvalidaException();
            }
        }

        private void ValidarFechaRecibido() 
        {
            if (FechaRecibido < FechaRealizado) 
            {
                throw new FechaRecibidoPedidoInvalidaException();
            }
        }

        //private void ValidarAnulado() 
        //{

        //}

        private void ValidarRecargo() 
        {
            if (Recargo < 0) 
            {
                throw new RecardoPedidoInvalidaException();
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
            if (Cliente == null) 
            {
                throw new ClientePedidoInvalidaException();
            }
        }
    }
}
