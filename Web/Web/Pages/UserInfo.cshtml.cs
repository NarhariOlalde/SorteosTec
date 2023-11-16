using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class UserInfoModel : PageModel
    {
        public int IdUsuario { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Correo { get; private set; }
        public string DatosBancarios { get; private set; }
        public string Sexo { get; private set; }
        public int Edad { get; private set; }
        public string Localizacion { get; private set; }
        public bool Administrador { get; private set; }

        //UserName
        public string nombreUsuario { get; private set; }
        public string passwordUsuario { get; private set; }

        public void OnGet()
        {
            IdUsuario = HttpContext.Session.GetInt32("id_usuario") ?? 0; // El valor por defecto en caso de que sea null
            Nombre = HttpContext.Session.GetString("nombre");
            Apellido = HttpContext.Session.GetString("apellido");
            Correo = HttpContext.Session.GetString("correo");
            DatosBancarios = HttpContext.Session.GetString("datos_bancarios");
            Sexo = HttpContext.Session.GetString("sexo");
            Edad = HttpContext.Session.GetInt32("edad") ?? 0; // El valor por defecto en caso de que sea null
            Localizacion = HttpContext.Session.GetString("localizacion");
            Administrador = HttpContext.Session.GetInt32("administrador") == 1;

            //UserName
            nombreUsuario = HttpContext.Session.GetString("nombreUsuario");
            passwordUsuario = HttpContext.Session.GetString("passwordUsuario");
        }
    }
}
