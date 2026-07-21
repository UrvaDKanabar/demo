using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAllocationController : ControllerBase
    {
       
        
            private readonly AppDbContext _context;
            public ProjectAllocationController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetProjectAllocation()
            {
                var ProjectAllocation = await _context.projectallocation.ToListAsync();
                return Ok(ProjectAllocation);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{ProjectAllocationId}")]
            public async Task<IActionResult> GetById(int ProjectAllocationId)
            {
                var ProjectAllocation = await _context.projectallocation.FindAsync(ProjectAllocationId);
                if (ProjectAllocation == null)
                {
                    return NotFound();
                }
                return Ok(ProjectAllocation);
            }
        }
    
}