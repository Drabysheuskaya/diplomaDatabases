using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MnemonicsTakeTwo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Group> Groups { get; set; }
        public required DbSet<ApplicationUser> Users { get; set; }
        public required DbSet<GroupUser> GroupUsers { get; set; }
        public required DbSet<Subject> Subjects { get; set; }
        public required DbSet<Department> Departments { get; set; }
        public required DbSet<Category> Categories { get; set; }
        public required DbSet<Mnemonic> Mnemonics { get; set; }
        public required DbSet<Definition> Definitions { get; set; }
        public required DbSet<MnemonicDefinition> MnemonicDefinitions { get; set; }
        public DbSet<CategoryMnemonic> CategoryMnemonics { get; set; }
        public DbSet<GroupMnemonic> GroupMnemonics { get; set; }
        public DbSet<RequestedMnemonic> RequestedMnemonics { get; set; }
        public DbSet<FavoriteMnemonic> FavoriteMnemonics { get; set; }
        public DbSet<FlashcardResult> FlashcardResults { get; set; }

    }
}

