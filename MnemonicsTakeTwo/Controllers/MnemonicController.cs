using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Services;
using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemonics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MnemonicController : ControllerBase
    {
        private readonly IMnemonicService _mnemonicService;

        public MnemonicController(IMnemonicService mnemonicService)
        {
            _mnemonicService = mnemonicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mnemonic>>> GetMnemonics()
        {
            return Ok(await _mnemonicService.GetMnemonicsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mnemonic>> GetMnemonic(int id)
        {
            var mnemonic = await _mnemonicService.GetMnemonicByIdAsync(id);
            if (mnemonic == null)
            {
                return NotFound();
            }
            return Ok(mnemonic);
        }

        [HttpPost]
        public async Task<ActionResult<Mnemonic>> AddMnemonic(Mnemonic mnemonic)
        {
            var createdMnemonic = await _mnemonicService.AddMnemonicAsync(mnemonic);
            return CreatedAtAction(nameof(GetMnemonic), new { id = createdMnemonic }, createdMnemonic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMnemonic(int id, Mnemonic mnemonic)
        {
            if (id != mnemonic.Id)
            {
                return BadRequest();
            }

            await _mnemonicService.UpdateMnemonicAsync(mnemonic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMnemonic(int id)
        {
            await _mnemonicService.DeleteMnemonicAsync(id);
            return NoContent();
        }
    }
}

