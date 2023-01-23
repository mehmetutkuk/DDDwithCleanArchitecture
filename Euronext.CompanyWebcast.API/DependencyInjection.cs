using Euronext.CompanyWebcast.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Euronext.CompanyWebcast.API.Common.Mapping;

namespace Euronext.CompanyWebcast.API;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CompanyWebcastProblemDetailFactory>();
        services.AddMappings();
        return services;
    }
}