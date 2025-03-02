using System.Collections.Generic;
using System.Threading.Tasks;
using MnemonicsTakeTwo.Data;

namespace MnemonicsTakeTwo.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
    }
}
