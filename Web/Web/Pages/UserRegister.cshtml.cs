using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Model;

namespace Web.Pages
{

    public class UserRegisterModel : PageModel
    {
        private readonly SorteosTecContext _context;

        public UserRegisterModel(SorteosTecContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Usuario NewUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Vuelve a mostrar la página con los errores de validación.
            }

            _context.Usuarios.Add(NewUser);
            await _context.SaveChangesAsync();
            return RedirectToPage("./UsuarioCreado"); // Redirecciona a la página de confirmación.
        }

    }
}
