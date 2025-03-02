using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class FlashcardResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [Required]
        public int MnemonicId { get; set; }
        public Mnemonic Mnemonic { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string SessionId { get; set; }

        public bool? KnewIt { get; set; }
    }
}

