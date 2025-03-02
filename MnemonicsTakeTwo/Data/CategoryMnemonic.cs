using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class CategoryMnemonic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int MnemonicId { get; set; }
        public Mnemonic Mnemonic { get; set; }
    }
}



