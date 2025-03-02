using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }

        // Navigation property
        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<GroupMnemonic> GroupMnemonics { get; set; } = new List<GroupMnemonic>();


    }
}
