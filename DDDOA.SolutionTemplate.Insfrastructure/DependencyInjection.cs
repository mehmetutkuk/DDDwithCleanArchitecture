using DDDOA.SolutionTemplate.Application.Common.Interfaces;
using DDDOA.SolutionTemplate.Insfrastructure.Persistence;
using DDDOA.SolutionTemplate.Insfrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDOA.SolutionTemplate.Insfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
          this IServiceCollection services,
          ConfigurationManager configuration)
        {
            services
                .AddPersistance();
            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            services.AddDbContext<CompanyWebcastDbContext>(options =>
                options.UseSqlServer("Server=db;Database=CompanyWebcast;User Id=sa;Password=Password@12345;TrustServerCertificate=true"));

            services.AddScoped<IForecastRepository, ForecastRepository>();
            return services;
        }
    }
}