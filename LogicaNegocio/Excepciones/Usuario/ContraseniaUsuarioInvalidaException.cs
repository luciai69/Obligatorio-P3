﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class ContraseniaUsuarioInvalidaException : UsuarioException
    {
        public ContraseniaUsuarioInvalidaException() : base("La contraseña no puede estar vacía.") { }
    }
}
