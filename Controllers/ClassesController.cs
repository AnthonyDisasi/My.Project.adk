using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DataContext;
using My.Project.adk.Models;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public ClassesController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classe>>> GetClasse()
        {
            return await _context.Classe.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> GetClasse(string id)
        {
            var classe = await _context.Classe.FindAsync(id);

            if (classe == null)
            {
                return NotFound();
            }

            return classe;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasse(string id, Classe classe)
        {
            if (id != classe.ID)
            {
                return BadRequest();
            }

            _context.Entry(classe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Classe>> PostClasse(Classe classe)
        {
            _context.Classe.Add(classe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasse", new { id = classe.ID }, classe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasse(string id)
        {
            var classe = await _context.Classe.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }

            _context.Classe.Remove(classe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasseExists(string id)
        {
            return _context.Classe.Any(e => e.ID == id);
        }
    }
}
