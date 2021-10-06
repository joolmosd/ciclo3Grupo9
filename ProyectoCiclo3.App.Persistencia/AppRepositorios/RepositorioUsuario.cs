using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuarios;
        private readonly AppContext _appContext = new AppContext();
 
    // public RepositorioUsuario()
    //     {
    //         usuarios= new List<Usuario>()
    //         {
    //             new Usuario{id=1,nombre="Camilo",apellidos= "Olmos",direccion= "Cll 7 # 94-78",telefono= "3132625232"},
    //             new Usuario{id=2,nombre="Andres",apellidos= "Duran",direccion= "Tv 56A # 74-30",telefono= "3167348452"},
    //             new Usuario{id=3,nombre="Tatiana",apellidos= "Prieto",direccion= "Cll 168 # 14-55",telefono= "3168528063"}
 
    //         };
    //     }
 
        public IEnumerable<Usuario> GetAll()
        {
            return _appContext.Usuarios;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuarios.Find(id);
        }


        public Usuario Create(Usuario newUsuario)
        {
             var addUsuario = _appContext.Usuarios.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;

        }


        public Usuario Update(Usuario newUsuario){
            var usuario =  _appContext.Usuarios.Find(newUsuario.id);

            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellidos = newUsuario.apellidos;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return usuario;
        }

        

        public void Delete(int id)
        {
        var user = _appContext.Usuarios.Find(id);
        if (user == null)
            return;
        _appContext.Usuarios.Remove(user);
        _appContext.SaveChanges();
        }

    }
}
        