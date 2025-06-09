using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamTaskManager.API.Data;
using TeamTaskManager.API.Models;

namespace TeamTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("tasks/{userId}")]
        public async Task<IActionResult> GetUserTasks(int userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.AssignedToUserId == userId)
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpPut("tasks/{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
