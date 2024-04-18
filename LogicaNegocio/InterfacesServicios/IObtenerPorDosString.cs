using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IObtenerPorDosString <T>
    {
        public T Ejecutar(string dato1, string dato2);
    }
}
