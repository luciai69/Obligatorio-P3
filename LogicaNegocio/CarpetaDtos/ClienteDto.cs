using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record ClienteDto(int Id, string Rut, string RazonSoc, string Calle, string Num, string Ciudad, int DistanciaPapeleria)
    {
        public List<Pedido> Pedidos { get; set; }
    }
}
