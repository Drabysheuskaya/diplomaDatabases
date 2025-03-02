using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName);
    }
}
