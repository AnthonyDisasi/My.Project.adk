using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DbFolder;
using My.Project.adk.Models;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcolesController : ControllerBase
    {
        private readonly DbProject _context;

        public EcolesController(DbProject context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ecole>>> GetEcole()
        {
            return await _context.Ecole.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ecole>> GetEcole(string id)
        {
            var ecole = await _context.Ecole.FindAsync(id);

            if (ecole == null)
            {
                return NotFound();
            }

            return ecole;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcole(string id, Ecole ecole)
        {
            if (id != ecole.ID)
            {
                return BadRequest();
            }

            _context.Entry(ecole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcoleExists(id))
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
        public async Task<ActionResult<Ecole>> PostEcole(Ecole ecole)
        {
            _context.Ecole.Add(ecole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcole", new { id = ecole.ID }, ecole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcole(string id)
        {
            var ecole = await _context.Ecole.FindAsync(id);
            if (ecole == null)
            {
                return NotFound();
            }

            _context.Ecole.Remove(ecole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EcoleExists(string id)
        {
            return _context.Ecole.Any(e => e.ID == id);
        }
    }
}
