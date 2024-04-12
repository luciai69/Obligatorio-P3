﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class NombreUsuarioInvalidaException : UsuarioException
    {
        public NombreUsuarioInvalidaException() : base("El nombre no puede estar vacío y debe tener formato correcto.")
        {

        }
    }
}
