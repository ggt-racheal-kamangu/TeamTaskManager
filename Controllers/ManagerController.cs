using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamTaskManager.API.Data;
using TeamTaskManager.API.Models;

// Alias the Task model to avoid conflict with System.Threading.Tasks.Task
using TaskModel = TeamTaskManager.API.Models.Task;

namespace TeamTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManagerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("tasks")]
        public async System.Threading.Tasks.Task<IActionResult> GetTasks()
        {
            var tasks = await _context.Tasks.Include(t => t.AssignedToUser).ToListAsync();
            return Ok(tasks);
        }

        [HttpPost("tasks")]
        public async System.Threading.Tasks.Task<IActionResult> CreateTask([FromBody] TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        [HttpPut("tasks/{id}")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateTask(int id, [FromBody] TaskModel task)
        {
            var existing = await _context.Tasks.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.DueDate = task.DueDate;
            existing.IsCompleted = task.IsCompleted;
            existing.AssignedToUserId = task.AssignedToUserId;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
