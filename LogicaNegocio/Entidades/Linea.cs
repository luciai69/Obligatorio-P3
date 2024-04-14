using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Linea;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Linea : IEntity, IValidable
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int CantUnidades { get; set; }
        public double PrecioUnitarioVigente { get; set; }

        public void Validar()
        {
            ValidarArticulo();
            ValidarCantidad();
        }

        private void ValidarArticulo() 
        { 
            if(Articulo == null)
            {
                throw new ArticuloLineaInvalidaException();
            }
        }

        private void ValidarCantidad()
        {
            if(CantUnidades <= 0)
            {
                throw new CantLineaInvalidaException();
            }
        }

        private void ValidarPrecio()
        {
            if(PrecioUnitarioVigente < 0)
            {
                throw new PrecioLineaInvalidaException();
            }
        }
    }
}
