using System;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Web.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public LoginModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string nombre, string password)
        {
            HttpContext.Session.SetString("nombreUsuario", nombre); // Almacenar el nombre de usuario
            HttpContext.Session.SetString("passwordUsuario", password); // Almacenar la contraseña

            var connectionString = Configuration.GetConnectionString("SorteosTecDB");

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT U.* FROM Usuario U INNER JOIN UserName UN ON U.id_usuario = UN.id_usuario WHERE UN.nombre = @nombre AND UN.password = @password", connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            id_usuario = reader.IsDBNull(reader.GetOrdinal("id_usuario")) ? 0 : reader.GetInt32("id_usuario"),
                            nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"),
                            apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString("apellido"),
                            correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? string.Empty : reader.GetString("correo"),
                            datos_bancarios = reader.IsDBNull(reader.GetOrdinal("datos_bancarios")) ? string.Empty : reader.GetString("datos_bancarios"),
                            sexo = reader.IsDBNull(reader.GetOrdinal("sexo")) ? string.Empty : reader.GetString("sexo"),
                            edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? 0 : reader.GetInt32("edad"),
                            localizacion = reader.IsDBNull(reader.GetOrdinal("localizacion")) ? string.Empty : reader.GetString("localizacion"),
                            administrador = reader.IsDBNull(reader.GetOrdinal("administrador")) ? false : reader.GetBoolean("administrador")
                        };

                        // Almacenar en la sesión
                        HttpContext.Session.SetInt32("id_usuario", usuario.id_usuario);
                        HttpContext.Session.SetString("nombre", usuario.nombre);
                        HttpContext.Session.SetString("apellido", usuario.apellido);
                        HttpContext.Session.SetString("correo", usuario.correo);
                        HttpContext.Session.SetString("datos_bancarios", usuario.datos_bancarios);
                        HttpContext.Session.SetString("sexo", usuario.sexo);
                        HttpContext.Session.SetInt32("edad", usuario.edad);
                        HttpContext.Session.SetString("localizacion", usuario.localizacion);
                        HttpContext.Session.SetInt32("administrador", usuario.administrador ? 1 : 0);

                        return RedirectToPage("/Index", new { InicioSesionExitoso = true });
                    }
                    else
                    {
                        return RedirectToPage("/Game");
                    }
                }
            }
        }
    }
}
