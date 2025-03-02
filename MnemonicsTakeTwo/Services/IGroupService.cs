using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MnemonicsTakeTwo.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<Group> AddGroupAsync(Group group);
        Task<Group> UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int id);

        Task<Group> GetGroupByCodeAsync(string code); // Add this method

    }
}

