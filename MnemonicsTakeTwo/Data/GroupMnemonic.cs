using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class GroupMnemonic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [Required]
        public int MnemonicId { get; set; }
        public Mnemonic Mnemonic { get; set; }
    }
}