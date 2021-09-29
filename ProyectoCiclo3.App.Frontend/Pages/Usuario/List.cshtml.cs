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
    public class ListUsuarioModel : PageModel
    {
        private readonly RepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> usuarios {get;set;}
 
    public ListUsuarioModel(RepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario = repositorioUsuario;
     }
 
    public void OnGet()
    {
        usuarios = repositorioUsuario.GetAll();
    }

    public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Usuario.id>0)
            {
            Usuario = repositorioUsuario.Update(Usuario);
            }
            return Page();
        }


    }
}
