using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record LineaDto
    {
        public int Id { get; set; }
        public int CantUnidades { get; set; }
        public double PrecioUnitarioVigente { get; set; }
    }
}
