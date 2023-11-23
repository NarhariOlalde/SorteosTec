using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Web.Model;


namespace Web.Pages
{

    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public RegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string nombre, string apellido, string correo, string datos_bancarios, string sexo, int edad, string localizacion, string user_name, string password, bool administrador = false)
        {
            string connectionString = _configuration.GetConnectionString("SorteosTecDB");
            int id_usuario = 0;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Iniciar una transacción
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar en la tabla Usuario
                        var queryUsuario = @"
                    INSERT INTO Usuario (nombre, apellido, correo, datos_bancarios, sexo, edad, localizacion) 
                    VALUES (@Nombre, @Apellido, @Correo, @DatosBancarios, @Sexo, @Edad, @Localizacion);
                    SELECT LAST_INSERT_ID();";

                        using (var commandUsuario = new MySqlCommand(queryUsuario, connection, transaction))
                        {
                            commandUsuario.Parameters.AddWithValue("@Nombre", nombre);
                            commandUsuario.Parameters.AddWithValue("@Apellido", apellido);
                            commandUsuario.Parameters.AddWithValue("@Correo", correo);
                            commandUsuario.Parameters.AddWithValue("@DatosBancarios", datos_bancarios);
                            commandUsuario.Parameters.AddWithValue("@Sexo", sexo);
                            commandUsuario.Parameters.AddWithValue("@Edad", edad);
                            commandUsuario.Parameters.AddWithValue("@Localizacion", localizacion);

                            // Ejecutar el comando y obtener el ID del usuario insertado
                            id_usuario = Convert.ToInt32(commandUsuario.ExecuteScalar());
                        }

                        if (id_usuario > 0)
                        {
                            // Insertar en la tabla UserName
                            var queryUserName = @"
                                    INSERT INTO UserName (id_usuario, nombre, password) 
                                    VALUES (@IdUsuario, @UserName, @Password)";

                            using (var commandUserName = new MySqlCommand(queryUserName, connection, transaction))
                            {
                                commandUserName.Parameters.AddWithValue("@IdUsuario", id_usuario);
                                commandUserName.Parameters.AddWithValue("@UserName", user_name);
                                commandUserName.Parameters.AddWithValue("@Password", password);

                                commandUserName.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaction.Commit();

                            HttpContext.Session.SetString("nombreUsuario", user_name); // Almacenar el nombre de usuario
                            HttpContext.Session.SetString("passwordUsuario", password); // Almacenar la contraseña
                        }

                        // Almacenar en la sesión
                        HttpContext.Session.SetInt32("id_usuario", id_usuario);
                        HttpContext.Session.SetString("nombre", nombre);
                        HttpContext.Session.SetString("apellido", apellido);
                        HttpContext.Session.SetString("correo", correo);
                        HttpContext.Session.SetString("datos_bancarios", datos_bancarios);
                        HttpContext.Session.SetString("sexo", sexo);
                        HttpContext.Session.SetInt32("edad", edad);
                        HttpContext.Session.SetString("localizacion", localizacion);
                        HttpContext.Session.SetInt32("administrador", administrador ? 1 : 0);


                        // Redireccionar a la página de inicio o de éxito
                        return RedirectToPage("/Index", new { registroExitoso = true });
                    }
                    catch
                    {
                        // En caso de error, revertir la transacción
                        transaction.Rollback();

                        // Manejar el caso de error, devolver un mensaje de error o redirigir a una página de error
                        return RedirectToPage("/Index", new { registroExitoso = false, errorRegistro = true });
                    }

                }
            }
        }
    }
}



