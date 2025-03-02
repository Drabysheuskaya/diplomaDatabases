using MnemonicsTakeTwo.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public class FlashcardResultService : IFlashcardResultService
    {
        private readonly ApplicationDbContext _context;

        public FlashcardResultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFlashcardResultAsync(FlashcardResult flashcardResult)
        {
            _context.FlashcardResults.Add(flashcardResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FlashcardResult>> GetFlashcardResultsByGroupIdAsync(int groupId, string userId)
        {
            return await _context.FlashcardResults
                .Where(fr => fr.GroupId == groupId && fr.UserId == userId)
                .Include(fr => fr.Mnemonic)
                .ToListAsync();
        }

        public async Task<List<FlashcardResult>> GetFlashcardResultsByGroupIdAndSessionIdAsync(int groupId, string userId, string sessionId) // Implement this method
        {
            return await _context.FlashcardResults
                .Where(fr => fr.GroupId == groupId && fr.UserId == userId && fr.SessionId == sessionId)
                .Include(fr => fr.Mnemonic)
                .ToListAsync();
        }
    }
}

