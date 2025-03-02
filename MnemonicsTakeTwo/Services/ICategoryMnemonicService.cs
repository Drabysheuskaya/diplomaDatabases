using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public interface ICategoryMnemonicService
    {
        Task<IEnumerable<CategoryMnemonic>> GetCategoryMnemonicsAsync();
        Task<CategoryMnemonic> GetCategoryMnemonicByIdAsync(int id);
        Task<CategoryMnemonic> AddCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic);
        Task<CategoryMnemonic> UpdateCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic);
        Task DeleteCategoryMnemonicAsync(int id);
        Task<IEnumerable<Mnemonic>> GetMnemonicsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Mnemonic>> GetApprovedAndVisibleMnemonicsByCategoryIdAsync(int categoryId);
        Task<List<Mnemonic>> GetMnemonicsByCategoryIdsAsync(List<int> categoryIds);
    }
}
