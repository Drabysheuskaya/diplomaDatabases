using MnemonicsTakeTwo.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public class FavoriteMnemonicService : IFavoriteMnemonicService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMnemonicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavoriteMnemonic>> GetFavoriteMnemonicsByUserIdAsync(string userId)
        {
            return await _context.FavoriteMnemonics
                .Include(fm => fm.Mnemonic)
                .Where(fm => fm.UserId == userId)
                .ToListAsync();
        }

        public async Task AddFavoriteMnemonicAsync(FavoriteMnemonic favoriteMnemonic)
        {
            _context.FavoriteMnemonics.Add(favoriteMnemonic);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavoriteMnemonicAsync(string userId, int mnemonicId)
        {
            var favoriteMnemonic = await _context.FavoriteMnemonics
                .FirstOrDefaultAsync(fm => fm.UserId == userId && fm.MnemonicId == mnemonicId);
            if (favoriteMnemonic != null)
            {
                _context.FavoriteMnemonics.Remove(favoriteMnemonic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsFavoriteMnemonicAsync(string userId, int mnemonicId)
        {
            return await _context.FavoriteMnemonics
                .AnyAsync(fm => fm.UserId == userId && fm.MnemonicId == mnemonicId);
        }
    }
}

