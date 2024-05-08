using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos
{
    public record ArticuloDto(int Id, string Nombre, string Descripcion, string Codigo, double Precio, int Stock)
    {
    }
}
