using Microsoft.AspNetCore.Identity;

namespace MnemonicsTakeTwo.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // Navigation property
        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<RequestedMnemonic> RequestedMnemonics { get; set; }

    }

}
