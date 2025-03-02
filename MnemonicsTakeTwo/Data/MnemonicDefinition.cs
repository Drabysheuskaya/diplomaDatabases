using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class MnemonicDefinition
    {
        [Key]
        public int Id { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public Definition Definition { get; set; }
        
    }
}
