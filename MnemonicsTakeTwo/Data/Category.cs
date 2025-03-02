using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MnemonicsTakeTwo.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Navigation property
        public ICollection<CategoryMnemonic> CategoryMnemonics { get; set; } = new List<CategoryMnemonic>();
    }
}



