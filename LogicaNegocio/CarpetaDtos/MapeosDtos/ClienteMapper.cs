using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.CarpetaDtos.MapeosDtos
{
    public class ClienteMapper
    {
        public static Cliente FromDto(ClienteDto clienteDto)
        {
            return new Cliente()
            {
                Id = clienteDto.Id,
                Rut = clienteDto.Rut,
                RazonSoc = clienteDto.RazonSoc,
                Direccion = new Direccion(clienteDto.Calle, clienteDto.Num, clienteDto.Ciudad, clienteDto.DistanciaPapeleria),
                Pedidos = clienteDto.Pedidos
            };
        }

        public static ClienteDto ToDto(Cliente cliente)
        {
            return new ClienteDto(cliente.Id, cliente.Rut, cliente.RazonSoc, cliente.Direccion.Calle, cliente.Direccion.Num, cliente.Direccion.Ciudad, cliente.Direccion.DistanciaPapeleria);

        }

        public static IEnumerable<ClienteDto> ToListaDto(IEnumerable<Cliente> clientes)
        {
            List<ClienteDto> aux = new List<ClienteDto>();

            foreach (var cliente in clientes)
            {
                ClienteDto clienteDto = ToDto(cliente);
                aux.Add(clienteDto);
            }
            return aux;
        }
    }
}
