

using LogicaNegocio.Excepciones.ValueObjects.Direccion;

namespace LogicaNegocio.ValueObjects
{
    public record Direccion
    {
        public string Calle { get; }
        public string Num { get; }
        public string Ciudad { get; }
        public int DistanciaPapeleria { get; }

        public Direccion()
        {

        }
        public Direccion(string calle, string num, string ciudad, int distancia)
        {
            Calle = calle;
            Num = num;
            Ciudad = ciudad;
            DistanciaPapeleria = distancia;
            Validar();
        }

        private void Validar()
        {
            ValidarCalle();
            ValidarNum();
            ValidarCiudad();
            ValidarDistanciaPaleleria();
        }

        private void ValidarCalle()
        {
            if (string.IsNullOrEmpty(Calle))
            {
                throw new CalleDireccionInvalidaException();
            }
        }

        private void ValidarNum()
        {
            if (string.IsNullOrEmpty(Num))
            {
                throw new NumDireccionInvalidaException();
            }
        }

        private void ValidarCiudad()
        {
            if(string.IsNullOrEmpty(Ciudad))
            {
                throw new CiudadDireccionInvalidaException();
            }
        }

        private void ValidarDistanciaPaleleria()
        {
            if(DistanciaPapeleria < 0)
            {
                throw new DistanciaDireccionInvalidaException();
            }
        }

    }
}
