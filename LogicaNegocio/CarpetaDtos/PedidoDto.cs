using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public class PedidoDto
    {
        public PedidoDto(int id, DateTime fechaEntrega, string nombreCliente, double montoTotal, string discriminator)
        {
            Id = id;
            FechaEntrega = fechaEntrega;
            ClienteNombre = nombreCliente;
            MontoTotal = montoTotal;
            Discriminator = discriminator;
        }

        public PedidoDto() { }

        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string ClienteNombre { get; set; }
        public double MontoTotal { get; set; }
        public string Discriminator { get; set; }

    }
}
