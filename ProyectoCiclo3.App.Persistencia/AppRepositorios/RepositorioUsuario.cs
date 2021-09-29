using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuarios;
 
    public RepositorioUsuario()
        {
            usuarios= new List<Usuario>()
            {
                new Usuario{id=1,nombre="Camilo",apellidos= "Olmos",direccion= "Cll 7 # 94-78",telefono= "3132625232"},
                new Usuario{id=2,nombre="Andres",apellidos= "Duran",direccion= "Tv 56A # 74-30",telefono= "3167348452"},
                new Usuario{id=3,nombre="Tatiana",apellidos= "Prieto",direccion= "Cll 168 # 14-55",telefono= "3168528063"}
 
            };
        }
 
        public IEnumerable<Usuario> GetAll()
        {
            return usuarios;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return usuarios.SingleOrDefault(b => b.id == id);
        }


        public Usuario Update(Usuario newUsuario){
            var usuario =  usuarios.SingleOrDefault(b => b.id == newUsuario.id);
            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellidos = newUsuario.apellidos;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
            }
        return usuario;
        }

    }
}
