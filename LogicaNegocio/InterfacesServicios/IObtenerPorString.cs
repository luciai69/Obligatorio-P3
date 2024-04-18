using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IObtenerPorString<T>
    {
        public IEnumerable<T> Ejecutar(string dato);
    }
}
