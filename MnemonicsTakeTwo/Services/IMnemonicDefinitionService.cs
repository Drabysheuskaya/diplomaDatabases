using MnemonicsTakeTwo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MnemonicsTakeTwo.Services
{
    public interface IMnemonicDefinitionService
    {
        Task<IEnumerable<MnemonicDefinition>> GetMnemonicDefinitionsAsync();
        Task<MnemonicDefinition> GetMnemonicDefinitionByIdAsync(int id);
        Task<MnemonicDefinition> AddMnemonicDefinitionAsync(MnemonicDefinition mnemonicDefinition);
        Task<MnemonicDefinition> UpdateMnemonicDefinitionAsync(MnemonicDefinition mnemonicDefinition);
        Task DeleteMnemonicDefinitionAsync(int id);
    }
}


