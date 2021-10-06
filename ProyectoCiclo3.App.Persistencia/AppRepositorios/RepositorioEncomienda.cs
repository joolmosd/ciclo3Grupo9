using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> encomiendas;
        private readonly AppContext _appContext = new AppContext();
 
    // public RepositorioEncomienda()
    //     {
    //         encomiendas= new List<Encomienda>()
    //         {
    //             new Encomienda{id=1,descripcion= "Medicina",peso= 100,tipo= "mar",presentacion= "Caja"},
    //             new Encomienda{id=2,descripcion= "Tecnologia",peso= 20,tipo= "terrestre",presentacion= "Plastico"},
    //             new Encomienda{id=3,descripcion= "Jugueteria",peso= 5,tipo= "aereo",presentacion= "Bolsa"}
 
    //         };
    //     }
 
        public IEnumerable<Encomienda> GetAll()
        {
           return _appContext.Encomiendas;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return _appContext.Encomiendas.Find(id);
        }


        public Encomienda Create(Encomienda newEncomienda)
        {
             var addEncomienda = _appContext.Encomiendas.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }

        public Encomienda Update(Encomienda newEncomienda){
            var encomienda = _appContext.Encomiendas.Find(newEncomienda.id);
            if(encomienda != null){
                encomienda.descripcion = newEncomienda.descripcion;
                encomienda.peso = newEncomienda.peso;
                encomienda.tipo = newEncomienda.tipo;
                encomienda.presentacion = newEncomienda.presentacion;
            //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return encomienda;
        }

        public void Delete(int id)
        {
            var enco =  _appContext.Encomiendas.Find(id);

            if (enco == null)
                return;
            _appContext.Encomiendas.Remove(enco);
            _appContext.SaveChanges();
        
        }

    }
}
