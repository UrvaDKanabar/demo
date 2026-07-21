using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StatusController : ControllerBase
        {
            private readonly AppDbContext _context;
            public StatusController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetStatus()
            {
                var status = await _context.taskstatus.ToListAsync();
                return Ok(status);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{StatusId}")]
            public async Task<IActionResult> GetById(int TaskStatusId)
            {
                var status = await _context.taskstatus.FindAsync(TaskStatusId);
                if (status == null)
                {
                    return NotFound();
                }
                return Ok(status);
            }
        }
    }
}