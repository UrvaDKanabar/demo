using demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMasterController : ControllerBase
    {
        
            private readonly AppDbContext _context;
            public ProjectMasterController(AppDbContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<IActionResult> GetProjectMaster()
            {
                var ProjectMaster = await _context.projectmaster.ToListAsync();
                return Ok(ProjectMaster);
            }
            //[HttpGet(template: "(PriorityId)")]
            [HttpGet("{ProjectMasterId}")]
            public async Task<IActionResult> GetById(int ProjectMasterId)
            {
                var ProjectMaster = await _context.projectmaster.FindAsync(ProjectMasterId);
                if (ProjectMaster == null)
                {
                    return NotFound();
                }
                return Ok(ProjectMaster);
            }
        }
}
