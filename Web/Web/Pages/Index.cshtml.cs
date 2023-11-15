using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class IndexModel : PageModel
{
    public bool RegistroExitoso { get; private set; }
    public string NombreUsuario { get; private set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(bool registroExitoso = false)
    {
        RegistroExitoso = registroExitoso;
        NombreUsuario = TempData["NombreUsuario"] as string;
    }
}

