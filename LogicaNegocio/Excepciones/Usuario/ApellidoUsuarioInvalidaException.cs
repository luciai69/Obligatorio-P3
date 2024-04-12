﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class ApellidoUsuarioInvalidaException : UsuarioException
    {
        public ApellidoUsuarioInvalidaException() : base("El apellido no puede estar vacío y debe tener formato adecuado.") { }
    }
}
