using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DbFolder;
using My.Project.adk.Models;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        private readonly DbProject _context;

        public ElevesController(DbProject context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleve()
        {
            return await _context.Eleve.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(string id)
        {
            var eleve = await _context.Eleve.FindAsync(id);

            if (eleve == null)
            {
                return NotFound();
            }

            return eleve;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(string id, Eleve eleve)
        {
            if (id != eleve.ID)
            {
                return BadRequest();
            }

            _context.Entry(eleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
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
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve)
        {
            _context.Eleve.Add(eleve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleve", new { id = eleve.ID }, eleve);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleve(string id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            _context.Eleve.Remove(eleve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleveExists(string id)
        {
            return _context.Eleve.Any(e => e.ID == id);
        }
    }
}
