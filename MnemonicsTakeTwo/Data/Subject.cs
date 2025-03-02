using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Group> Groups { get; set; } = new List<Group>();

    }
}
