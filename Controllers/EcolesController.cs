using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using My.Project.adk.Services;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcolesController : ControllerBase
    {
        private readonly IEcoleService _ecoleService;

        public EcolesController(IEcoleService ecoleService)
        {
            _ecoleService = ecoleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ecole>>> GetEcole()
        {
            return await _ecoleService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ecole>> GetEcole(string id)
        {
            return await _ecoleService.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcole(string id, Ecole ecole)
        {
            if (id != ecole.ID)
            {
                return BadRequest();
            }

            await _ecoleService.Update(ecole);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Ecole>> PostEcole(Ecole ecole_)
        {
            var ecole = await _ecoleService.Create(ecole_);
            return CreatedAtAction("GetEcole", new { id = ecole.ID }, ecole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcole(string id)
        {
            var ecole = await _ecoleService.Get(id);
            if (ecole == null)
            {
                return NotFound();
            }
            await _ecoleService.Delete(ecole.ID);
            return NoContent();
        }
    }
}
