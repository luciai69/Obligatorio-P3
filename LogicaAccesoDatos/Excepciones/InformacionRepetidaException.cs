using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    internal class InformacionRepetidaException : RepositorioException
    {
        public InformacionRepetidaException() : base("No se pueden utilizar datos repetidos.") { }
    
    }
}
