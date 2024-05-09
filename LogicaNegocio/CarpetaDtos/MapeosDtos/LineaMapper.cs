using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class LineaMapper
    {
        public static Linea FromDto(LineaDto lineaDto)
        {
            return new Linea()
            {
                Id = lineaDto.Id,
                ArticuloId = lineaDto.ArticuloId,
                CantUnidades = lineaDto.CantUnidades,
                PrecioUnitarioVigente = lineaDto.PrecioUnitarioVigente,
            };
        }

        public static LineaDto ToDto(Linea linea)
        {
            return new LineaDto(linea.Id, linea.ArticuloId, linea.Articulo.Nombre, linea.Articulo.Descripcion, linea.Articulo.Codigo, linea.CantUnidades, linea.PrecioUnitarioVigente);

        }

        public static IEnumerable<LineaDto> ToListaDto(IEnumerable<Linea> lineas)
        {
            List<LineaDto> aux = new List<LineaDto>();

            foreach (var linea in lineas)
            {
                LineaDto lineaDto = ToDto(linea);
                aux.Add(lineaDto);
            }
            return aux;
        }

        public static List<Linea> FromListaDto(List<LineaDto> lineasDto)
        {
            List<Linea> aux = new List<Linea>();

            foreach (var lineaDto in lineasDto)
            {
                Linea linea = FromDto(lineaDto);
                aux.Add(linea);
            }
            return aux;
        }
    }
}
