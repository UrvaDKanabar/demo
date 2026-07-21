using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {

   
        private readonly AppDbContext _context;
        public UserRoleController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetUserRole()
        {
            var UserRole= await _context.userrole.ToListAsync();
            return Ok(UserRole);
        }
        //[HttpGet(template: "(PriorityId)")]
        [HttpGet("{UserRoleId}")]
        public async Task<IActionResult> GetById(int UserRoleId)
        {
            var UserRole = await _context.userrole.FindAsync(UserRoleId);
            if (UserRole == null)
            {
                return NotFound();
            }
            return Ok(UserRole);
        }
    }
}
