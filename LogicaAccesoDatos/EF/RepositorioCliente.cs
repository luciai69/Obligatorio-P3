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
            return _context.Clientes.
                AsEnumerable().
                ToList();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetByMonto(int monto)
        {
            var clientes = _context.Clientes
                .Where(cli => cli.Pedidos
                .Any(ped => ped.MontoTotal >= monto))
                .OrderBy(cli => cli.Rut);
            return clientes.ToList();
        }


        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetByString(string dato) 
        {
            return _context.Clientes.
                Where(cliente => cliente.Rut.ToLower().Contains(dato.ToLower()));
        }
    }
}
