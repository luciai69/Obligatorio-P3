using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class CodigoRepetidoRepositorioException : RepositorioException
    {
        public CodigoRepetidoRepositorioException() : base("El código ingresado ya se encuentra en uso.") { }
    
    }
}
