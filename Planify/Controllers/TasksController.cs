using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planify.Models.Domain;
using Planify.Models.DTOs;
using System;
using Planify.Data;


namespace Planify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var task = new TaskItems
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
