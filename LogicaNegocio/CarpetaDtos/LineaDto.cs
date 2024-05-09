using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record LineaDto
    {
        public LineaDto(int id, int articuloId, string nombre, string descripcion, string codigo, int cantUnidades, double precioUnitarioVigente)
        {
            Id = id;
            ArticuloId = articuloId;
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            CantUnidades = cantUnidades;
            PrecioUnitarioVigente = precioUnitarioVigente;
        }

        public LineaDto() { }

        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public int CantUnidades { get; set; }
        public double PrecioUnitarioVigente { get; set; }

    }

}
