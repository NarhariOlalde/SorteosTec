using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Web.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var connection = new MySqlConnection(_configuration.GetConnectionString("SorteosTecDB")))
            {
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM Usuario WHERE nombre = @Nombre AND password = @Password", connection);
                command.Parameters.AddWithValue("@Nombre", Username);
                command.Parameters.AddWithValue("@Password", Password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        HttpContext.Session.SetString("Username", Username);
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ErrorMessage = "Invalid username or password";
                        return Page();
                    }
                }
            }
        }
    }
}
