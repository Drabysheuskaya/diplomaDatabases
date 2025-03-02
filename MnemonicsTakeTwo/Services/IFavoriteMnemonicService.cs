using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public interface IFavoriteMnemonicService
    {
        Task<List<FavoriteMnemonic>> GetFavoriteMnemonicsByUserIdAsync(string userId);
        Task AddFavoriteMnemonicAsync(FavoriteMnemonic favoriteMnemonic);
        Task RemoveFavoriteMnemonicAsync(string userId, int mnemonicId);
        Task<bool> IsFavoriteMnemonicAsync(string userId, int mnemonicId);
    }
}

