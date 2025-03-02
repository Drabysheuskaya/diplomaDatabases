using System.Collections.Generic;
using System.Threading.Tasks;
using MnemonicsTakeTwo.Data;

public interface IGroupMnemonicService
{
    Task<IEnumerable<Mnemonic>> GetMnemonicsByGroupIdAsync(int groupId);
    Task AddGroupMnemonicAsync(GroupMnemonic groupMnemonic);
    Task RemoveGroupMnemonicAsync(int groupId, int mnemonicId); // Add this method


}