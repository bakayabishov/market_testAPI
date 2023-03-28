using Buisness.Utilities.AutoMapperProfiles;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buisness;

public static class DependencyInjection
{
    public static void BusinessDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles));

        services.AddFluentValidationAutoValidation();

    }
}