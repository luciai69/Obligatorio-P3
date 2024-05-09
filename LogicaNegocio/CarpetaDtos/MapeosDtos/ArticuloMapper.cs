using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class ArticuloMapper
    {
        public static Articulo FromDto(ArticuloDto articuloDto)
        {
            return new Articulo()
            {
                Id = articuloDto.Id,
                Nombre = articuloDto.Nombre,
                Descripcion = articuloDto.Descripcion,
                Codigo = articuloDto.Codigo,
                Precio = articuloDto.Precio,
                Stock = articuloDto.Stock,
            };
        }
        public static ArticuloDto ToDto(Articulo art)
        {
            return new ArticuloDto(art.Id, art.Nombre, art.Descripcion, art.Codigo, art.Precio, art.Stock);
        }

        public static IEnumerable<ArticuloDto> ToListaDto(IEnumerable<Articulo> articulos)
        {
            List<ArticuloDto> aux = new List<ArticuloDto>();

            foreach (var art in articulos)
            {
                ArticuloDto articuloDto = ToDto(art);
                aux.Add(articuloDto);
            }
            return aux;
        }
    }
}
