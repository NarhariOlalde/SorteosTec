using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace Web.Pages
{

    public class StatsModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public StatsModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var connectionString = Configuration.GetConnectionString("SorteosTecDB");

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Obtener la puntuación del usuario actual
                
            }
            return Page();
        }
    }
}
