using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;

public class GroupMnemonicService : IGroupMnemonicService
{
    private readonly ApplicationDbContext _context;

    public GroupMnemonicService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mnemonic>> GetMnemonicsByGroupIdAsync(int groupId)
    {
        return await _context.GroupMnemonics
            .Where(gm => gm.GroupId == groupId)
            .Select(gm => gm.Mnemonic)
            .ToListAsync();
    }
    public async Task AddGroupMnemonicAsync(GroupMnemonic groupMnemonic)
    {
        _context.GroupMnemonics.Add(groupMnemonic);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveGroupMnemonicAsync(int groupId, int mnemonicId)
    {
        var groupMnemonic = await _context.GroupMnemonics
            .FirstOrDefaultAsync(gm => gm.GroupId == groupId && gm.MnemonicId == mnemonicId);
        if (groupMnemonic != null)
        {
            _context.GroupMnemonics.Remove(groupMnemonic);
            await _context.SaveChangesAsync();
        }
    }
}