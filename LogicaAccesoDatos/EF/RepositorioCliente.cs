using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private PapeleriaContext _context;

        public RepositorioCliente(PapeleriaContext papeleriaContext)
        {
            _context = papeleriaContext;
        }


        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Cliente> GetByMonto(int monto)
        //{
        //    return _context.Clientes.
        //        Include(cliente => cliente.Pedidos).
        //}


        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Usuario> GetByMonto(int monto)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Cliente> GetByString(string dato) 
        {
            return _context.Clientes.
                Where(cliente => cliente.Rut.ToLower().Contains(dato.ToLower()));
        }
    }
}
