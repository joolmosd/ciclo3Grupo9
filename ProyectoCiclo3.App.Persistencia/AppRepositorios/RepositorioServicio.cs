using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> servicios;
 
    public RepositorioServicio()
        {
            servicios= new List<Servicio>()
            {
                new Servicio{id=1,origen=1,destino= 3,fecha= new DateTime(2008, 5, 1, 8, 30, 52),hora= "13:00",encomienda= 2},
                new Servicio{id=2,origen=2,destino= 1,fecha= new DateTime(2010, 5, 1, 8, 30, 52),hora= "08:00",encomienda= 1},
                new Servicio{id=3,origen=3,destino= 2,fecha= new DateTime(2021, 5, 1, 8, 30, 52),hora= "10:00",encomienda= 3}
 
            };
        }
 
        public IEnumerable<Servicio> GetAll()
        {
            return servicios;
        }
 
        public Servicio GetServicioWithId(int id){
            return servicios.SingleOrDefault(b => b.id == id);
        }

        public Servicio Create(Servicio newServicio)
        {
           if(servicios.Count > 0){
           newServicio.id=servicios.Max(r => r.id) +1; 
            }else{
               newServicio.id = 1; 
            }
           servicios.Add(newServicio);
           return newServicio;
        }

        public Servicio Update(Servicio newServicio){
            var servicio = servicios.SingleOrDefault(b => b.id == newServicio.id);
            if(servicio != null){
                servicio.origen = newServicio.origen;
                servicio.destino = newServicio.destino;
                servicio.fecha = newServicio.fecha;
                servicio.hora = newServicio.hora;
                servicio.encomienda = newServicio.encomienda;
            }
        return servicio;
        }


        public void Delete(int id)
        {
        var service= servicios.SingleOrDefault(b => b.id == id);
        servicios.Remove(service);
        return;
        }

        
    }
}