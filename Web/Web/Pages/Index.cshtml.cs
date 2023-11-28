using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class IndexModel : PageModel
{
    public bool RegistroExitoso { get; private set; }
    public bool InicioSesionExitoso { get; private set; }
    public bool ErrorContraseña { get; private set; }
    public bool ErrorRegistro { get; private set; }

    public string Nombre { get; private set; }
    public string Apellido { get; private set; }

    public bool Administrador { get; private set; }

    public bool MostrarModalNoAutenticado { get; set; }

    public bool SesionCerrada { get; private set; }

    public void OnGet(bool registroExitoso = false, bool inicioSesionExitoso = false, bool errorContraseña = false, bool errorRegistro = false, bool mostrarModalNoAutenticado = false, bool sesionCerrada = false)
    {
        RegistroExitoso = registroExitoso;
        InicioSesionExitoso = inicioSesionExitoso;
        ErrorContraseña = errorContraseña;
        ErrorRegistro = errorRegistro;
        MostrarModalNoAutenticado = mostrarModalNoAutenticado;
        SesionCerrada = sesionCerrada;

        Nombre = HttpContext.Session.GetString("nombre");
        Apellido = HttpContext.Session.GetString("apellido");
    }
}

