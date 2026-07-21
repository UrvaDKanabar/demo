using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        
            private readonly AppDbContext _context;
            public UserTypeController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetUserType()
            {
                var UserType = await _context.usertype.ToListAsync();
                return Ok(UserType);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{UserTypeId}")]
            public async Task<IActionResult> GetById(int UserTypeId)
            {
                var UserType = await _context.usertype.FindAsync(UserTypeId);
                if (UserType == null)
                {
                    return NotFound();
                }
                return Ok(UserType);
            }
        }
}
