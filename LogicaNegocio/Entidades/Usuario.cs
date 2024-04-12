using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }

        public void Validar()
        {
            ValidarMail();
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();
        }

        private void ValidarMail() //TODO Validar que no se repita el mail.
        { 
            if (string.IsNullOrEmpty(Mail))
            {
                throw new MailUsuarioInvalidaException();
            }
        }

        private void ValidarNombre() //TODO Validar los temas de formato
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreUsuarioInvalidaException();
            }
        }

        private void ValidarApellido() //TODO Validar los temas de formato
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new ApellidoUsuarioInvalidaException();
            }
        }

        private void ValidarContrasenia() //TODO Validar los temas de formato
        {
            if (string.IsNullOrEmpty(Contrasenia))
            {
                throw new ContraseniaUsuarioInvalidaException();
            }
        }
        public void Update(Usuario obj)
        {
            obj.Validar();
            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
            Contrasenia = obj.Contrasenia;
        }
    }
}
