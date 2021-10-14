using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Dominio;
using ProyectoCiclo3.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    [Authorize]
    public class EditUsuarioModel : PageModel
    {
       private readonly RepositorioUsuario repositorioUsuario;
              [BindProperty]
              public Usuario Usuario {get;set;}
 
        public EditUsuarioModel(RepositorioUsuario repositorioUsuario)
       {
            this.repositorioUsuario = repositorioUsuario;
       }
 
        public IActionResult OnGet(int usuarioId)
        {
                Usuario = repositorioUsuario.GetUsuarioWithId(usuarioId);
                return Page();
 
        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Usuario.id>0)
            {
            Usuario = repositorioUsuario.Update(Usuario);
            }
            return RedirectToPage("./List");
        }

    }
}
