using MnemonicsTakeTwo.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public class GroupUserService : IGroupUserService
    {
        private readonly ApplicationDbContext _context;

        public GroupUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupUser>> GetGroupUsersAsync()
        {
            return await _context.GroupUsers.Include(gu => gu.User).Include(gu => gu.Group).ToListAsync();
        }

        public async Task<GroupUser> GetGroupUserByIdAsync(int id)
        {
            return await _context.GroupUsers.Include(gu => gu.User).Include(gu => gu.Group).FirstOrDefaultAsync(gu => gu.Id == id);
        }

        public async Task<GroupUser> AddGroupUserAsync(GroupUser groupUser)
        {
            _context.GroupUsers.Add(groupUser);
            await _context.SaveChangesAsync();
            return groupUser;
        }

        public async Task<GroupUser> UpdateGroupUserAsync(GroupUser groupUser)
        {
            _context.GroupUsers.Update(groupUser);
            await _context.SaveChangesAsync();
            return groupUser;
        }

        public async Task DeleteGroupUserAsync(int id)
        {
            var groupUser = await _context.GroupUsers.FindAsync(id);
            if (groupUser != null)
            {
                _context.GroupUsers.Remove(groupUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
