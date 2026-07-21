using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

            private readonly AppDbContext _context;
            public TaskController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetTask()
            {
                var Task = await _context.task.ToListAsync();
                return Ok(Task);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{TaskId}")]
            public async Task<IActionResult> GetById(int TaskId)
            {
                var Task = await _context.task.FindAsync(TaskId);
                if (Task == null)
                {
                    return NotFound();
                }
                return Ok(Task);
            }
        }
}
