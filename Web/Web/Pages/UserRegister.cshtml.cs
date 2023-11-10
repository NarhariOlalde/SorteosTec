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
        public Dictionary<string, string> Estados { get; set; }
        public string EstadoSeleccionado { get; set; }


        public UserRegisterModel(SorteosTecContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            Estados = new Dictionary<string, string>{
                { "AGS", "Aguascalientes" },
                { "BC", "Baja California" },
                { "BCS", "Baja California Sur" },
                { "CAMP", "Campeche" },
                { "CHIS", "Chiapas" },
                { "CHIH", "Chihuahua" },
                { "CDMX", "Ciudad de México" },
                { "COAH", "Coahuila" },
                { "COL", "Colima" },
                { "DGO", "Durango" },
                { "GTO", "Guanajuato" },
                { "GRO", "Guerrero" },
                { "HGO", "Hidalgo" },
                { "JAL", "Jalisco" },
                { "MEX", "Estado de México" },
                { "MICH", "Michoacán" },
                { "MOR", "Morelos" },
                { "NAY", "Nayarit" },
                { "NL", "Nuevo León" },
                { "OAX", "Oaxaca" },
                { "PUE", "Puebla" },
                { "QRO", "Querétaro" },
                { "QROO", "Quintana Roo" },
                { "SLP", "San Luis Potosí" },
                { "SIN", "Sinaloa" },
                { "SON", "Sonora" },
                { "TAB", "Tabasco" },
                { "TAMPS", "Tamaulipas" },
                { "TLAX", "Tlaxcala" },
                { "VER", "Veracruz" },
                { "YUC", "Yucatán" },
                { "ZAC", "Zacatecas" }
            };
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
