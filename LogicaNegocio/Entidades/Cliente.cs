using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;


namespace LogicaNegocio.Entidades
{
    public class Cliente : IEntity, IValidable
    {
        public int Id { get; set; }
        public string RazonSoc { get; set; }
        public string Rut { get; set; }
        public Direccion Direccion { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public void Validar()
        {
            ValidarRazonSoc();
            ValidarRut();
            ValidarDireccion();
        }

        private void ValidarRazonSoc()
        {
            if (string.IsNullOrEmpty(RazonSoc))
            {
                throw new RazonSocClienteInvalidaException();
            }
        }

        private void ValidarRut()
        {
            if (string.IsNullOrEmpty(Rut))
            {
                throw new RutClienteInvalidaException();
            }
        }

        private void ValidarDireccion()
        {
            if (Direccion == null)
            {
                throw new DireccionClienteInvalidaException();
            }

        }
    }
}
