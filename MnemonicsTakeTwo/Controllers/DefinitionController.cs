using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Services;
using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemonics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IDefinitionService _definitionService;

        public DefinitionController(IDefinitionService definitionService)
        {
            _definitionService = definitionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Definition>>> GetDefinitions()
        {
            return Ok(await _definitionService.GetDefinitionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Definition>> GetDefinition(int id)
        {
            var definition = await _definitionService.GetDefinitionByIdAsync(id);
            if (definition == null)
            {
                return NotFound();
            }
            return Ok(definition);
        }

        [HttpPost]
        public async Task<ActionResult<Definition>> AddDefinition(Definition definition)
        {
            var createdDefinition = await _definitionService.AddDefinitionAsync(definition);
            return CreatedAtAction(nameof(GetDefinition), new { id = createdDefinition.Id }, createdDefinition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDefinition(int id, Definition definition)
        {
            if (id != definition.Id)
            {
                return BadRequest();
            }

            await _definitionService.UpdateDefinitionAsync(definition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefinition(int id)
        {
            await _definitionService.DeleteDefinitionAsync(id);
            return NoContent();
        }
    }
}

