using MnemonicsTakeTwo.Data;
using System.ComponentModel.DataAnnotations;

public class Mnemonic
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Phrase { get; set; }

    [Required]
    public string Description { get; set; }
    
    public byte[]? Image { get; set; }

    public bool IsApproved { get; set; } = false;
    public bool IsVisible { get; set; } = false;



    // Navigation property
    public ICollection<CategoryMnemonic>? CategoryMnemonics { get; set; }
    public ICollection<GroupMnemonic>? GroupMnemonics { get; set; }
    public ICollection<RequestedMnemonic>? RequestedMnemonics { get; set; }
}
