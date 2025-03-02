using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class FavoriteMnemonic
    {
        [Key]
        public int Id { get; set; }
        public int MnemonicId { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
