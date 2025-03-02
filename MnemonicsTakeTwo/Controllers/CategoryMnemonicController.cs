using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Data;
using MnemonicsTakeTwo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryMnemonicController : ControllerBase
    {
        private readonly ICategoryMnemonicService _categoryMnemonicService;

        public CategoryMnemonicController(ICategoryMnemonicService categoryMnemonicService)
        {
            _categoryMnemonicService = categoryMnemonicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryMnemonic>>> GetCategoryMnemonics()
        {
            return Ok(await _categoryMnemonicService.GetCategoryMnemonicsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryMnemonic>> GetCategoryMnemonic(int id)
        {
            var categoryMnemonic = await _categoryMnemonicService.GetCategoryMnemonicByIdAsync(id);
            if (categoryMnemonic == null)
            {
                return NotFound();
            }
            return Ok(categoryMnemonic);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryMnemonic>> AddCategoryMnemonic(CategoryMnemonic categoryMnemonic)
        {
            var createdCategoryMnemonic = await _categoryMnemonicService.AddCategoryMnemonicAsync(categoryMnemonic);
            return CreatedAtAction(nameof(GetCategoryMnemonic), new { id = createdCategoryMnemonic.Id }, createdCategoryMnemonic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryMnemonic(int id, CategoryMnemonic categoryMnemonic)
        {
            if (id != categoryMnemonic.Id)
            {
                return BadRequest();
            }

            await _categoryMnemonicService.UpdateCategoryMnemonicAsync(categoryMnemonic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryMnemonic(int id)
        {
            await _categoryMnemonicService.DeleteCategoryMnemonicAsync(id);
            return NoContent();
        }
    }
}
