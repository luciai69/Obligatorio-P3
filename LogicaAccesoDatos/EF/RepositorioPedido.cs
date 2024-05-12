using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
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
            var pedidos = _context.Pedidos
                 .Where(p => p.FechaRealizado.Date == dato.Date)
                 .Where(p => p.Anulado == false)
                 .Where(p => p.FechaEntrega.Date >= DateTime.Now.Date)
                 .Include(cli => cli.Cliente)
                 .AsEnumerable().
                  ToList();
            return pedidos;


        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        }

        public void Anular(int id)
        {
            Pedido pedido = GetById(id);
            if (pedido == null)
            {
                throw new NotFoundException();
            }
            pedido.Anular();
            _context.Pedidos.Update(pedido);
            _context.SaveChanges(true);
        }


        public IEnumerable<Pedido> GetByBool(bool dato)
        {
            var pedidos = _context.Pedidos
                 .Where(p => p.Anulado == dato)
                 .Include(cli => cli.Cliente)
                 .OrderBy(p => p.FechaRealizado)
                 .AsEnumerable().
                  ToList();
            return pedidos;
        }

        public void Update(int id, Pedido obj)
        {
            throw new NotImplementedException();
        }
    }
}
