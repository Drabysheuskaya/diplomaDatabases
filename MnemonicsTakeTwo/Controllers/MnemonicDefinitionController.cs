using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Services;
using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemonics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MnemonicDefinitionController : ControllerBase
    {
        private readonly IMnemonicDefinitionService _mnemonicDefinitionService;

        public MnemonicDefinitionController(IMnemonicDefinitionService mnemonicDefinitionService)
        {
            _mnemonicDefinitionService = mnemonicDefinitionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MnemonicDefinition>>> GetMnemonicDefinitions()
        {
            return Ok(await _mnemonicDefinitionService.GetMnemonicDefinitionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MnemonicDefinition>> GetMnemonicDefinition(int id)
        {
            var mnemonicDefinition = await _mnemonicDefinitionService.GetMnemonicDefinitionByIdAsync(id);
            if (mnemonicDefinition == null)
            {
                return NotFound();
            }
            return Ok(mnemonicDefinition);
        }

        [HttpPost]
        public async Task<ActionResult<MnemonicDefinition>> AddMnemonicDefinition(MnemonicDefinition mnemonicDefinition)
        {
            var createdMnemonicDefinition = await _mnemonicDefinitionService.AddMnemonicDefinitionAsync(mnemonicDefinition);
            return CreatedAtAction(nameof(GetMnemonicDefinition), new { id = createdMnemonicDefinition.Id }, createdMnemonicDefinition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMnemonicDefinition(int id, MnemonicDefinition mnemonicDefinition)
        {
            if (id != mnemonicDefinition.Id)
            {
                return BadRequest();
            }

            await _mnemonicDefinitionService.UpdateMnemonicDefinitionAsync(mnemonicDefinition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMnemonicDefinition(int id)
        {
            await _mnemonicDefinitionService.DeleteMnemonicDefinitionAsync(id);
            return NoContent();
        }
    }
}


