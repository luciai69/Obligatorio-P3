using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System.Net.Mail;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Contrasenia { get; set; }
        public string Discriminator { get; set; }

        public void Validar()
        {
            ValidarMail();
            ValidarContrasenia();
        }

        private void ValidarMail() //TODO Validar que no se repita el mail.
        { 
            if (string.IsNullOrEmpty(Mail) || !EsValido(Mail))
            {
                throw new MailUsuarioInvalidaException();
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
            NombreCompleto = obj.NombreCompleto;
            Contrasenia = obj.Contrasenia;
        }

        private static bool EsValido(string email)
        {
            var valido = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valido = false;
            }

            return valido;
        }
    }
}
