using DDDOA.SolutionTemplate.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DDDOA.SolutionTemplate.API.Common.Mapping;

namespace DDDOA.SolutionTemplate.API;


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