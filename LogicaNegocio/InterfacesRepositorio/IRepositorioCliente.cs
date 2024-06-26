﻿using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> GetByString(string dato);

        public IEnumerable<Cliente> GetByMonto(int monto);

    }
}
