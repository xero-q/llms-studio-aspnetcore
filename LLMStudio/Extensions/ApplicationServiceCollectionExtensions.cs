using LLMStudio.Repositories;

namespace LLMStudio.Extensions;
    
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    } 
}
