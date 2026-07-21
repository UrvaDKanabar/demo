using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            var role = await _context.role.ToListAsync();
            return Ok(role);
        }
        //[HttpGet(template: "(PriorityId)")]
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetById(int roleId)
        {
            var role = await _context.role.FindAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
    }
}

