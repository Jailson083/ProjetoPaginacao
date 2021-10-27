using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPaginacao.Data;
using ProjetoPaginacao.Models;
using ProjetoPaginacao.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPaginacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private new readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var todo = await _context.Todo
                .AsNoTracking()
                .Select(t => new 
                { 
                    id = t.Id,
                    title = t.Title,
                    done = t.Done,
                    createdAt = t.CreatedAt
                })
                .ToListAsync();
              
            return Ok(todo);

        }

        [HttpPost("create")]
        public async Task<IActionResult> PostAsync(TodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo
            {
                Title = model.Title,
                Done = model.Done,
                CreatedAt = DateTime.Now,
            };

            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);

        }
    }
}
