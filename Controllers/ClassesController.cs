using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using My.Project.adk.Services;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClasseService _classeService;

        public ClassesController(IClasseService classeService)
        {
            _classeService = classeService;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<IEnumerable<Classe>>> GetClasse()
        {
            return await _classeService.Get();
        }

        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Classe>> GetClasse(string id)
        {
            return await _classeService.Get(id);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutClasse(string id, Classe classe)
        {
            if (id != classe.ID)
            {
                return BadRequest();
            }

            await _classeService.Update(classe);

            return NoContent();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Classe>> PostClasse(Classe classe_)
        {
            var classe = await _classeService.Create(classe_);
            return CreatedAtAction("GetClasse", new { id = classe.ID }, classe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasse(string id)
        {
            var classe = await _classeService.Get(id);
            if (classe == null)
            {
                return NotFound();
            }
            await _classeService.Delete(classe.ID);
            return NoContent();
        }
    }
}
