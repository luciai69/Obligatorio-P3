﻿using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.Entidades;
using LogicaAccesoDatos.Excepciones;

namespace LogicaAccesoDatos.EF
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        private PapeleriaContext _context;

        public RepositorioArticulo (PapeleriaContext papeleriaContext)
        {
            _context = papeleriaContext;
        }

        public void Add(Articulo obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            _context.Articulos.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Articulo articulo = GetById(id);

            if (articulo == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            _context.Articulos.Remove(articulo);
            _context.SaveChanges();
        }

        public IEnumerable<Articulo> GetAll()
        {
            return _context.Articulos.ToList();
        }

        public Articulo GetById(int id)
        {
            return _context.Articulos.FirstOrDefault(articulo => articulo.Id == id);
        }

        public Articulo GetByName(string name) //TODO Como uso esto para el validar?
        {
            return _context.Articulos.FirstOrDefault(articulo => articulo.Nombre == name);
        }

        public void Update(int id, Articulo obj)
        {
            Articulo articulo = GetById(id);
            if(articulo == null)
            {
                throw new NotFoundException();
            }
            articulo.Update(obj);
            _context.Articulos.Update(articulo);
            _context.SaveChanges(true);
        }
    }
}