using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public class CategoryMnemonicService : ICategoryMnemonicService
    {
        private readonly ApplicationDbContext _context;

        public CategoryMnemonicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryMnemonic>> GetCategoryMnemonicsAsync()
        {
            return await _context.CategoryMnemonics.ToListAsync();
        }

        public async Task<CategoryMnemonic> GetCategoryMnemonicByIdAsync(int id)
        {
            return await _context.CategoryMnemonics.FindAsync(id);
        }

        public async Task<CategoryMnemonic> AddCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic)
        {
            _context.CategoryMnemonics.Add(categoryMnemonic);
            await _context.SaveChangesAsync();
            return categoryMnemonic;
        }

        public async Task<CategoryMnemonic> UpdateCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic)
        {
            _context.Entry(categoryMnemonic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoryMnemonic;
        }

        public async Task DeleteCategoryMnemonicAsync(int id)
        {
            var categoryMnemonic = await _context.CategoryMnemonics.FindAsync(id);
            if (categoryMnemonic != null)
            {
                _context.CategoryMnemonics.Remove(categoryMnemonic);
                await _context.SaveChangesAsync();
            }
        }

        // New method to get mnemonics by category ID
        public async Task<IEnumerable<Mnemonic>> GetMnemonicsByCategoryIdAsync(int categoryId)
        {
            return await _context.CategoryMnemonics
                .Where(cm => cm.CategoryId == categoryId)
                .Select(cm => cm.Mnemonic)
                .ToListAsync();
        }

        public async Task<List<Mnemonic>> GetMnemonicsByCategoryIdsAsync(List<int> categoryIds)
        {
            return await _context.CategoryMnemonics
                .Where(cm => categoryIds.Contains(cm.CategoryId))
                .Select(cm => cm.Mnemonic)
                .Distinct()
                .ToListAsync();
        }

        // New method to get approved and visible mnemonics by category ID
        public async Task<IEnumerable<Mnemonic>> GetApprovedAndVisibleMnemonicsByCategoryIdAsync(int categoryId)
        {
            return await _context.CategoryMnemonics
                .Where(cm => cm.CategoryId == categoryId && cm.Mnemonic.IsApproved && cm.Mnemonic.IsVisible)
                .Select(cm => cm.Mnemonic)
                .ToListAsync();
        }
    }
}


