﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IEditar<T>
    {
        public void Ejecutar(int id, T obj);
    }
}
