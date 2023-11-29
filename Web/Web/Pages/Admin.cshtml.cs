using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using Web.Model;

namespace Web.Pages;

public class AdminModel : PageModel
{
    private readonly IConfiguration Configuration;

    public AdminModel(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public int TotalUsuarios { get; private set; }
    public int MaximaPuntuacion { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var genderDistribution = new Dictionary<string, float>();
        var connectionString = Configuration.GetConnectionString("SorteosTecDB");

        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Obtener distribución de género
            using (var genderCommand = new MySqlCommand("SELECT sexo, COUNT(*) FROM Usuario GROUP BY sexo", connection))
            using (var genderReader = await genderCommand.ExecuteReaderAsync())
            {
                int totalUsers = 0;
                while (await genderReader.ReadAsync())
                {
                    var gender = genderReader.GetString(0);
                    var count = genderReader.GetInt32(1);
                    totalUsers += count;
                    genderDistribution[gender] = count; // Almacenar conteo temporalmente
                }

                // Convertir conteos a porcentajes
                foreach (var gender in genderDistribution.Keys.ToList())
                {
                    genderDistribution[gender] = (genderDistribution[gender] / totalUsers) * 100;
                }
            }

            using (var ageCommand = new MySqlCommand("SELECT edad FROM Usuario", connection))
            using (var ageReader = await ageCommand.ExecuteReaderAsync())
            {
                var ageDistribution = new Dictionary<string, int>();
                while (await ageReader.ReadAsync())
                {
                    var age = ageReader.GetInt32(0);
                    var ageRange = ((age - 18) / 10) * 10 + 18; // Comienza rangos desde 18
                    var ageRangeString = $"{ageRange} - {ageRange + 9}";
                    if (!ageDistribution.ContainsKey(ageRangeString))
                    {
                        ageDistribution[ageRangeString] = 0;
                    }
                    ageDistribution[ageRangeString]++;
                }

                // Devolvemos el diccionario de distribución de edades a la vista en formato JSON
                ViewData["AgeDistribution"] = ageDistribution;
            }

            // Obtener cantidad total de usuarios
            using (var usersCommand = new MySqlCommand("SELECT COUNT(*) FROM Usuario", connection))
            using (var usersReader = await usersCommand.ExecuteReaderAsync())
            {
                if (await usersReader.ReadAsync())
                {
                    TotalUsuarios = usersReader.GetInt32(0);
                }
            }

            // Obtener máxima puntuación
            using (var scoreCommand = new MySqlCommand("SELECT MAX(puntuacion_maxima) FROM UserGame", connection))
            using (var scoreReader = await scoreCommand.ExecuteReaderAsync())
            {
                if (await scoreReader.ReadAsync())
                {
                    MaximaPuntuacion = scoreReader.IsDBNull(0) ? 0 : scoreReader.GetInt32(0);
                }
            }
        }

        ViewData["GenderDistribution"] = genderDistribution;
        return Page();
    }
}
