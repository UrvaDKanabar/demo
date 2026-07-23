using demo.Data;
using demo.Models;
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
        [HttpPost]
        public async Task<IActionResult> Create(ProjectTask task)
        {
            _context.task.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }
        [HttpPut("{TaskId}")]
        public async Task<IActionResult> Update(int TaskId, ProjectTask task)
        {
            if (TaskId != task.TaskId)
                return BadRequest();

            var oldTask = await _context.task.FindAsync(TaskId);

            oldTask.AssignedScore = task.AssignedScore;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{TaskId}")]
        public async Task<IActionResult> Delete(int TaskId)
        {
            var task = await _context.task.FindAsync(TaskId);

            if (task == null)
                return NotFound();

            _context.task.Remove(task);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
