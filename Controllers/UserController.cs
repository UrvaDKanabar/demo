using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _context.user.ToListAsync();
            return Ok(user);
        }
        //[HttpGet(template: "(PriorityId)")]
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetById(int UserId)
        {
            var user = await _context.user.FindAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
