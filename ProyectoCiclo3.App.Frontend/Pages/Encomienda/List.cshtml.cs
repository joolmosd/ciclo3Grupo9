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
        [BindProperty]
        public Encomienda enco {get;set;}
        public IEnumerable<Encomienda> Encomienda { get; set; }

        public ListEncomiendaModel(RepositorioEncomienda repositorioEncomienda)
        {
            this.repositorioEncomienda = repositorioEncomienda;
        }

        public void OnGet()
        {
            Encomienda = repositorioEncomienda.GetAll();
        }

        public IActionResult OnPost() //envio de información
    {
        if(enco.id>0)
        {
        repositorioEncomienda.Delete(enco.id);
        }
        return RedirectToPage("./List");
    }
    }

}
