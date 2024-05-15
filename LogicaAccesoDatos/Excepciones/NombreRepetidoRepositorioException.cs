using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class NombreRepetidoRepositorioException : RepositorioException
    {
        public NombreRepetidoRepositorioException() : base("El nombre ingresado ya se encuentra en uso.") { }
    }
}
