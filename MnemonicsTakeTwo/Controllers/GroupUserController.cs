using Microsoft.AspNetCore.Mvc;
using MnemonicsTakeTwo.Services;
using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mnemonics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUserController : ControllerBase
    {
        private readonly IGroupUserService _groupUserService;

        public GroupUserController(IGroupUserService groupUserService)
        {
            _groupUserService = groupUserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUser>>> GetGroupUsers()
        {
            return Ok(await _groupUserService.GetGroupUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUser>> GetGroupUser(int id)
        {
            var groupUser = await _groupUserService.GetGroupUserByIdAsync(id);
            if (groupUser == null)
            {
                return NotFound();
            }
            return Ok(groupUser);
        }

        [HttpPost]
        public async Task<ActionResult<GroupUser>> AddGroupUser(GroupUser groupUser)
        {
            var createdGroupUser = await _groupUserService.AddGroupUserAsync(groupUser);
            return CreatedAtAction(nameof(GetGroupUser), new { id = createdGroupUser.Id }, createdGroupUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupUser(int id, GroupUser groupUser)
        {
            if (id != groupUser.Id)
            {
                return BadRequest();
            }

            await _groupUserService.UpdateGroupUserAsync(groupUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupUser(int id)
        {
            await _groupUserService.DeleteGroupUserAsync(id);
            return NoContent();
        }
    }
}

