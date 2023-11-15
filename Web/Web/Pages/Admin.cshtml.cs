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

    public List<Usuario> Usuarios { get; set; }

    public void OnGet()
    {
        Usuarios = new List<Usuario>();
        var connectionString = Configuration.GetConnectionString("SorteosTecDB");

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Usuario", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuarios.Add(new Usuario
                    {
                        id_usuario = reader.IsDBNull(reader.GetOrdinal("id_usuario")) ? 0 : reader.GetInt32("id_usuario"),
                        nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"),
                        apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString("apellido"),
                        correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? string.Empty : reader.GetString("correo"),
                        datos_bancarios = reader.IsDBNull(reader.GetOrdinal("datos_bancarios")) ? string.Empty : reader.GetString("datos_bancarios"),
                        sexo = reader.IsDBNull(reader.GetOrdinal("sexo")) ? string.Empty : reader.GetString("sexo"),
                        edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? 0 : reader.GetInt32("edad"),
                        localizacion = reader.IsDBNull(reader.GetOrdinal("localizacion")) ? string.Empty : reader.GetString("localizacion")
                    });
                }
            }
        }
    }
}
