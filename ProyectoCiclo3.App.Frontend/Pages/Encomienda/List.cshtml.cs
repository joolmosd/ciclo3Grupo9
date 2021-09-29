using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Dominio;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class ListEncomiendaModel : PageModel
    {
        private readonly RepositorioEncomienda repositorioEncomienda;
        public IEnumerable<Encomienda> encomiendas {get;set;}
 
    public ListEncomiendaModel(RepositorioEncomienda repositorioEncomienda)
    {
        this.repositorioEncomienda = repositorioEncomienda;
     }
 
    public void OnGet()
    {
        encomiendas = repositorioEncomienda.GetAll();
    }

    public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Encomienda.id>0)
            {
            Encomienda = repositorioEncomienda.Update(Encomienda);
            }
            return Page();
        }


    }

}
