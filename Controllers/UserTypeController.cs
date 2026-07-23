using demo.Data;
using demo.Models;
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
        [HttpPost]
        public async Task<IActionResult> Create(UserType userType)
        {
            _context.usertype.Add(userType);
            await _context.SaveChangesAsync();

            return Ok(userType);
        }
        [HttpPut("{UserTypeId}")]
        public async Task<IActionResult> Update(int UserTypeId, UserType userType)
        {
            if (UserTypeId != userType.UserTypeId)
                return BadRequest();

            var oldUserType = await _context.usertype.FindAsync(UserTypeId);

            oldUserType.UserTypeName = userType.UserTypeName;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{UserTypeId}")]
        public async Task<IActionResult> Delete(int UserTypeId)
        {
            var usertype = await _context.usertype.FindAsync(UserTypeId);

            if (usertype == null)
                return NotFound();

            _context.usertype.Remove(usertype);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
