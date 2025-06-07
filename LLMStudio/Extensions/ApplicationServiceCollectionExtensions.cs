using FluentValidation;
using LLMStudio.Repositories;
using LLMStudio.Services;

namespace LLMStudio.Extensions;
    
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        
        return services;
    } 
}
