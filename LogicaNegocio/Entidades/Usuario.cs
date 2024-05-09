using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaEncripada { get; set; }
        public string Discriminator { get; set; }

        public void Validar()
        {
            ValidarMail();
            ValidarContrasenia();
            ContraseniaEncripada = EncodeStringToBase64(Contrasenia);
        }

        private void ValidarMail() //TODO Validar que no se repita el mail.
        {
            var valEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (string.IsNullOrEmpty(Mail) || !valEmail.IsMatch(Mail))
            {
                throw new MailUsuarioInvalidaException();
            }
            
        }


        private void ValidarContrasenia() //TODO Validar los temas de formato
        {
            var valContrasenia = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[,.!;]).{6,}$");

            if (string.IsNullOrEmpty(Contrasenia) || !valContrasenia.IsMatch(Contrasenia))
            {
                throw new ContraseniaUsuarioInvalidaException();
            }
        }
        public void Update(Usuario obj)
        {
            obj.Validar();
            NombreCompleto = obj.NombreCompleto;
            Contrasenia = obj.Contrasenia;
            ContraseniaEncripada = EncodeStringToBase64(Contrasenia);
        }

        public string EncodeStringToBase64(string stringToEncode)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToEncode));
        }

        public string DecodeStringFromBase64(string stringToDecode)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
        }
    }
}
