using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    internal class ArticuloMapper
    {
        public static ArticuloDto ToDto(Articulo art)
        {
            return new ArticuloDto(art.Id, art.Nombre, art.Descripcion, art.Codigo, art.Precio, art.Stock);
        }
    }
}
