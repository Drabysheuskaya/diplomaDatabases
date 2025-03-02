using System.Collections.Generic;
using System.Threading.Tasks;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public interface IMnemonicService
    {
        Task<IEnumerable<Mnemonic>> GetMnemonicsAsync();
        Task<Mnemonic> GetMnemonicByIdAsync(int id);
        Task<int> AddMnemonicAsync(Mnemonic mnemonic);
        Task<Mnemonic> UpdateMnemonicAsync(Mnemonic mnemonic);
        Task DeleteMnemonicAsync(int id);

        Task AddCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic);
        Task AddRequestedMnemonicAsync(RequestedMnemonic requestedMnemonic);
        Task<List<RequestedMnemonic>> GetRequestedMnemonicsAsync(); // Add this method
        Task ApproveMnemonicAsync(int mnemonicId); // Add this method
        Task RejectMnemonicAsync(int mnemonicId); // Add this method

        Task<RequestedMnemonic> GetRequestedMnemonicByIdAsync(int mnemonicId); // Add this method


    }
}

