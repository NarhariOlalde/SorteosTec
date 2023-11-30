using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Web.Pages
{
    public class StatsModel : PageModel
    {
        private readonly IConfiguration Configuration;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public int UserScore { get; set; }
        public int PlayedTime { get; private set; }

        public StatsModel(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var connectionString = Configuration.GetConnectionString("SorteosTecDB");

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Obtener la puntuación del usuario actual
                var userId = HttpContextAccessor.HttpContext.Session.GetInt32("id_usuario");

                if (userId.HasValue)
                {
                    var query = "SELECT * FROM UserGame WHERE id_usuario = @UserId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId.Value);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                UserScore = reader.GetInt32("puntuacion_maxima");
                                PlayedTime = reader.GetInt32("tiempo_jugado");
                            }
                        }
                    }
                }
            }
            return Page();
        }
    }
}
