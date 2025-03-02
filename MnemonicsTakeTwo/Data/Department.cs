using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
}
