using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class IndexModel : PageModel
{
    public bool RegistroExitoso { get; private set; }
    public bool InicioSesionExitoso { get; private set; }

    //public string NombreUsuario { get; private set; } //Temporal //corregir//

    public string Nombre { get; private set; }
    public string Apellido { get; private set; }

    public bool Administrador { get; private set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(bool registroExitoso = false, bool inicioSesionExitoso = false)
    {
        RegistroExitoso = registroExitoso;
        InicioSesionExitoso = inicioSesionExitoso;

        Nombre = HttpContext.Session.GetString("nombre");
        Apellido = HttpContext.Session.GetString("apellido");
    }
}

