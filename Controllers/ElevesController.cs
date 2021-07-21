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
    public class ElevesController : ControllerBase
    {
        private readonly IEleveService _eleveService;

        public ElevesController(IEleveService eleveService)
        {
            _eleveService = eleveService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleve()
        {
            return await _eleveService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(string id)
        {
            return await _eleveService.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(string id, [FromBody] Eleve eleve)
        {
            if (id != eleve.ID)
            {
                return BadRequest();
            }

            await _eleveService.Update(eleve);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve_)
        {
            var eleve = await _eleveService.Create(eleve_);
            return CreatedAtAction("GetEleve", new { id = eleve.ID }, eleve);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleve(string id)
        {
            var eleve = await _eleveService.Get(id);
            if (eleve == null)
            {
                return NotFound();
            }

            await _eleveService.Delete(eleve.ID);
            return NoContent();
        }
    }
}
