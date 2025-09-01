namespace BerryTestProject1.core;
using BerryTestProject1.Berry.Core;
using BerryTestProject1.Interfaces;
using BerryTestProject1.Repository;
using BerryTestProject1.Services;

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
