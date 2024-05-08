using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record PedidoExpressDto
    {
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
