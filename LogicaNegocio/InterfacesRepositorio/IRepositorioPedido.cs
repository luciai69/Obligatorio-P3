using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> GetByDate(DateTime dato);
    }
}
