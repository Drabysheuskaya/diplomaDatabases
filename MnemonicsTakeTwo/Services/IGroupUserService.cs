using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MnemonicsTakeTwo.Services
{
    public interface IGroupUserService
    {
        Task<IEnumerable<GroupUser>> GetGroupUsersAsync();
        Task<GroupUser> GetGroupUserByIdAsync(int id);
        Task<GroupUser> AddGroupUserAsync(GroupUser groupUser);
        Task<GroupUser> UpdateGroupUserAsync(GroupUser groupUser);
        Task DeleteGroupUserAsync(int id);
    }
}

