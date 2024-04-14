using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Cliente> GetByMonto(int monto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Usuario> GetByMonto(int monto)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Usuario> GetByName(string name) //TODO Como valida solo parte del string?
        //{
        //    return _context.Usuarios.Where(usuario => usuario.NombreCompleto. == name);
        //}
    }
}
