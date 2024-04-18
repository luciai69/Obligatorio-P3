using LogicaNegocio.CarpetaDtos.MapeosDtos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerPorDosString : IObtenerPorDosString<Usuario>
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerPorDosString(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public Usuario Ejecutar(string dato1, string dato2)
        {
            Usuario usuario = _repositorioUsuario.Login(dato1, dato2);
            return usuario;
        }
    }
}
