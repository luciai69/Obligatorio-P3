using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Excepciones.Usuario;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private PapeleriaContext _context;

        public RepositorioUsuario(PapeleriaContext papeleriaContext)
        {
            _context = papeleriaContext;
        }

        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            if(GetByEmail(obj.Mail) != null)
            {
                throw new InformacionRepetidaException();
            }
            obj.Validar();
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario usuario = GetById(id);

            if (usuario == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.
                AsEnumerable().
                ToList();
        }

        public Usuario Login(string email, string password)
        {
            Usuario usuario = GetByEmail(email);

            if (usuario == null)
            {
                throw new UsuarioNullException();
            }
            else if (usuario.ContraseniaEncripada != password)
            {
                throw new UsuarioNullException();
            }
            else{
                return usuario;
            }
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Mail == email);
        }
        public void Update(int id, Usuario obj)
        {
            Usuario usuario = GetById(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            usuario.Update(obj);
            _context.Usuarios.Update(usuario);
            _context.SaveChanges(true);
        }
    }
}
