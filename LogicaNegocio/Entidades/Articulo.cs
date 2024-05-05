using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Articulo: IEntity, IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            ValidarNombre();
            ValidarCodigo();
            ValidarDescripcion();
            ValidarPrecio();
            ValidarStock();
        }

        private void ValidarNombre() 
        {
            if (string.IsNullOrEmpty(Nombre) || Nombre.Length > ParametrosGenerales.MaxLargoArticulo || Nombre.Length < ParametrosGenerales.MinLargoArticulo) // TODO VALIDAR QUE NO SE REPITA
            {
                throw new NombreArticuloInvalidaException();
            }
        }

        private void ValidarDescripcion() 
        { 
            if(string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 5) 
            { 
                throw new DescripcionArticuloInvalidaException();
            }
        }
        private void ValidarCodigo()
        {
            if (string.IsNullOrEmpty(Codigo) || Codigo.Length != 13)
            {
                throw new CodigoArticuloInvalidaException();
            }
        }
        private void ValidarPrecio()
        {
            if(Precio<=0)
            {
                throw new PrecioArticuloInvalidaException();
            }
        }
        private void ValidarStock() 
        {
            if (Stock <= 0)
            {
                throw new StockArticuloInvalidaException();
            }
        }

        public void Update(Articulo obj)
        {
            obj.Validar();
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
            Codigo = obj.Codigo;
            Precio = obj.Precio;
            Stock = obj.Stock;
        }
    }
}
