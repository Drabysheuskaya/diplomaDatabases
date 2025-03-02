using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public class MnemonicDefinitionService : IMnemonicDefinitionService
    {
        private readonly ApplicationDbContext _context;

        public MnemonicDefinitionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MnemonicDefinition>> GetMnemonicDefinitionsAsync()
        {
            return await _context.MnemonicDefinitions.ToListAsync();
        }

        public async Task<MnemonicDefinition> GetMnemonicDefinitionByIdAsync(int id)
        {
            return await _context.MnemonicDefinitions.FindAsync(id);
        }

        public async Task<MnemonicDefinition> AddMnemonicDefinitionAsync(MnemonicDefinition mnemonicDefinition)
        {
            _context.MnemonicDefinitions.Add(mnemonicDefinition);
            await _context.SaveChangesAsync();
            return mnemonicDefinition;
        }

        public async Task<MnemonicDefinition> UpdateMnemonicDefinitionAsync(MnemonicDefinition mnemonicDefinition)
        {
            _context.Entry(mnemonicDefinition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return mnemonicDefinition;
        }

        public async Task DeleteMnemonicDefinitionAsync(int id)
        {
            var mnemonicDefinition = await _context.MnemonicDefinitions.FindAsync(id);
            if (mnemonicDefinition != null)
            {
                _context.MnemonicDefinitions.Remove(mnemonicDefinition);
                await _context.SaveChangesAsync();
            }
        }
    }
}


