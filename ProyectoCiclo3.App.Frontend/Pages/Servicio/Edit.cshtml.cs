using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;

namespace ProyectoCiclo3.App.Frontend.Pages
{
    [Authorize]
    public class EditServicioModel : PageModel
    {
        private readonly RepositorioServicio repositorioServicio;
        private readonly RepositorioUsuario repositorioUsuario;
        private readonly RepositorioEncomienda repositorioEncomienda;
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Encomienda> Encomiendas { get; set; }

        [BindProperty]
        public Servicio Servicio { get; set; }

        public EditServicioModel(RepositorioServicio repositorioServicio,RepositorioEncomienda repositorioEncomienda, RepositorioUsuario repositorioUsuario)
        {
            this.repositorioServicio = repositorioServicio;
            this.repositorioEncomienda = repositorioEncomienda;
            this.repositorioUsuario = repositorioUsuario;
        }

        public IActionResult OnGet(int servicioId)
        {
            Servicio = repositorioServicio.GetServicioWithId(servicioId);
            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Servicio.id > 0)
            {
                Servicio = repositorioServicio.Update(Servicio);
            }
            return RedirectToPage("./List");
        }
    }
}
