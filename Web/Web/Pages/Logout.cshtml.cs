using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                HttpContext.Response.Cookies.Delete(cookie.Key);
            }
            return RedirectToPage("/Index", new { sesionCerrada = true });
        }
    }
}
