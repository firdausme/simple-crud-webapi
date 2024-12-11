using SimpleCrudWebApi.Repositories;
using SimpleCrudWebApi.Services;

namespace SimpleCrudWebApi.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();

        return services;
    }
}