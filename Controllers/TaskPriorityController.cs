using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPriorityController : ControllerBase
    {
        
            private readonly AppDbContext _context;
            public TaskPriorityController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetTaskPriority()
            {
                var TaskPriority = await _context.taskpriority.ToListAsync();
                return Ok(TaskPriority);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{TaskPriorityId}")]
            public async Task<IActionResult> GetById(int TaskPriorityId)
            {
                var TaskPriority = await _context.taskpriority.FindAsync(TaskPriorityId);
                if (TaskPriority == null)
                {
                    return NotFound();
                }
                return Ok(TaskPriority);
            }
        }
}
