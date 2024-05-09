using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record PedidoExpressDto
    {
        public PedidoExpressDto(int id, DateTime fechaRealizado, int clienteId, DateTime fechaEntrega, double montoSubtotal, int cantidad, string discriminator)
        {
            Id = id;
            FechaRealizado = fechaRealizado;
            ClienteId = clienteId;
            FechaEntrega = fechaEntrega;
            MontoSubtotal = montoSubtotal;
            Cantidad = cantidad;
            Discriminator = discriminator;
        }

        public PedidoExpressDto() { }

        public int Id { get; set; }
        public DateTime FechaRealizado { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double MontoSubtotal { get; set; }
        public int Cantidad { get; set; }
        public string Discriminator { get; set; }
        public List<LineaDto> Lineas { get; set; } = new List<LineaDto>();
    }
}
