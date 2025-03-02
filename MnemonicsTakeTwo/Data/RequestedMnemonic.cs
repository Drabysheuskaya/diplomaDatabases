using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnemonicsTakeTwo.Data
{
    public class RequestedMnemonic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MnemonicId { get; set; }
        public Mnemonic Mnemonic { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int DepartmentId { get; set; }
    }
}