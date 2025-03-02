using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public interface IFlashcardResultService
    {
        Task AddFlashcardResultAsync(FlashcardResult flashcardResult);
        Task<List<FlashcardResult>> GetFlashcardResultsByGroupIdAsync(int groupId, string userId);
        Task<List<FlashcardResult>> GetFlashcardResultsByGroupIdAndSessionIdAsync(int groupId, string userId, string sessionId); // Add this method
    }
}

