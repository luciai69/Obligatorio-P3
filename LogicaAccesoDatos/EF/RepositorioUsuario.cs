using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using LogicaAccesoDatos.Excepciones;

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

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
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
