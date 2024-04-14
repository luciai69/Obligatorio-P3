﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.ValueObjects.NombreCompleto
{
    internal class ApellidoNombreCompletoInvalidaException : NombreCompletoException
    {
        public ApellidoNombreCompletoInvalidaException() : base("Ingrese un apellido.") { }
    }
}
