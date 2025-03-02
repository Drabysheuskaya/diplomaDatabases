using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MnemonicsTakeTwo.Services
{
    public interface IDefinitionService
    {
        Task<IEnumerable<Definition>> GetDefinitionsAsync();
        Task<Definition> GetDefinitionByIdAsync(int id);
        Task<Definition> AddDefinitionAsync(Definition definition);
        Task<Definition> UpdateDefinitionAsync(Definition definition);
        Task DeleteDefinitionAsync(int id);
    }
}

