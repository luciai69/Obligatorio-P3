using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record PedidoComunDto(int Id, DateTime FechaRealizado, int ClienteId, DateTime FechaEntrega, double MontoSubtotal, int Cantidad, string Discriminator)
    {
        public List<LineaDto> Lineas { get; set; } = new List<LineaDto>();
    }
}
