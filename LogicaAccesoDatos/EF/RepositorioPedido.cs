using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private PapeleriaContext _context;

        public RepositorioPedido(PapeleriaContext papeleriaContext)
        {
            _context = papeleriaContext;
        }

        public void Add(Pedido obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            _context.Pedidos.Add(obj);
            obj.CalcularRecargo();
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetByDate(DateTime dato)
        {
            throw new NotImplementedException();
        }

        public Pedido GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pedido obj)
        {
            throw new NotImplementedException();
        }
    }
}
