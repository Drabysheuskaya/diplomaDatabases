using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public class DefinitionService : IDefinitionService
    {
        private readonly ApplicationDbContext _context;

        public DefinitionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Definition>> GetDefinitionsAsync()
        {
            return await _context.Definitions.ToListAsync();
        }

        public async Task<Definition> GetDefinitionByIdAsync(int id)
        {
            return await _context.Definitions.FindAsync(id);
        }

        public async Task<Definition> AddDefinitionAsync(Definition definition)
        {
            _context.Definitions.Add(definition);
            await _context.SaveChangesAsync();
            return definition;
        }

        public async Task<Definition> UpdateDefinitionAsync(Definition definition)
        {
            _context.Entry(definition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return definition;
        }

        public async Task DeleteDefinitionAsync(int id)
        {
            var definition = await _context.Definitions.FindAsync(id);
            if (definition != null)
            {
                _context.Definitions.Remove(definition);
                await _context.SaveChangesAsync();
            }
        }
    }
}

