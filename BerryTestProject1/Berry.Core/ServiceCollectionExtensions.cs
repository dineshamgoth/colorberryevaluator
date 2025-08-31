namespace BerryTestProject1.core;
using BerryTestProject1.Services;
using BerryTestProject1.Interfaces;
using BerryTestProject1.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserDataService, UserDataService>();
        services.AddScoped<IUserDataRepository, UserDataRepository>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IPersonDetailsService, PersonDetailsService>();
        services.AddScoped<IPersonDetailsRepository, PersonDetailsRepository>();
        services.AddHttpContextAccessor();
        return services;
    }
}
