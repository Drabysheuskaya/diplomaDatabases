using Microsoft.Extensions.DependencyInjection;

namespace MnemonicsTakeTwo.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryMnemonicService, CategoryMnemonicService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDefinitionService, DefinitionService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupUserService, GroupUserService>();
            services.AddScoped<IMnemonicDefinitionService, MnemonicDefinitionService>();
            services.AddScoped<IMnemonicService, MnemonicService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IGroupMnemonicService, GroupMnemonicService>();
            services.AddScoped<IUserIdentityProcessor, UserIdentityProcessor>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFavoriteMnemonicService, FavoriteMnemonicService>();
            services.AddScoped<IFlashcardResultService, FlashcardResultService>();

            return services;
        }
    }
}
