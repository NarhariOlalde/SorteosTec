using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Web.Controller;
using Web.Database;
using Web.Model;

[Route("api/[controller]")]
[ApiController]
public class UserNameController : ControllerBase
{
    private readonly UserDbContext _context;

    public UserNameController(UserDbContext context)
    {
        _context = context;
    }

    // GET: api/UserName
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserName>>> GetUserName()
    {
        return await _context.UserName.ToListAsync();
    }

    // POST: api/UserName
    [HttpPost]
    public async Task<ActionResult<UserName>> PostUserName(UserName userName)
    {
        _context.UserName.Add(userName);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserName), new { id = userName.id_usuario }, userName);
    }
}
