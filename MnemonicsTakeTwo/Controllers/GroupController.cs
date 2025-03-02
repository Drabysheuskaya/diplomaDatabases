using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Services;
using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemonics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return Ok(await _groupService.GetGroupsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> AddGroup(Group group)
        {
            var createdGroup = await _groupService.AddGroupAsync(group);
            return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.Id }, createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            await _groupService.UpdateGroupAsync(group);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}

