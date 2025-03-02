using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class Definition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        // Navigation property
        public ICollection<MnemonicDefinition> MnemonicDefinitions { get; set; } = new List<MnemonicDefinition>();

    }
}
