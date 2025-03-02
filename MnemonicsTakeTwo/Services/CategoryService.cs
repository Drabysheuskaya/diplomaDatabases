using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesByDepartmentIdAsync(int departmentId)
        {
            return await _context.Categories
                .Where(c => c.DepartmentId == departmentId)
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
    }
}


