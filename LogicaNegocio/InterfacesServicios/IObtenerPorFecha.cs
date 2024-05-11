using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IObtenerPorFecha<T>
    {
        public IEnumerable<T> Ejecutar(DateTime fecha);
    }
}
