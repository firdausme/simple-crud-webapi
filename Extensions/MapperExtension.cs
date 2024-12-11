using SimpleCrudWebApi.Mapper;

namespace SimpleCrudWebApi.Extensions;

public static class MapperExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(StudentMapper));

        return services;
    }
}