using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class GameModel : PageModel
    {
        public IActionResult OnGet()
        {
            var isLoggedIn = HttpContext.Session.GetString("nombre") != null;

            if (!isLoggedIn)
            {
                // Redirigir al index y pasar un parámetro para indicar que se debe mostrar el modal
                return RedirectToPage("Index", new { mostrarModalNoAutenticado = true });
            }
            return Page();
        }
    }
}
