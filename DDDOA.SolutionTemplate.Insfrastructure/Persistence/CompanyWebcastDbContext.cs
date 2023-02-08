using DDDOA.SolutionTemplate.Domain.ForecastAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDDOA.SolutionTemplate.Insfrastructure.Persistence;


public class CompanyWebcastDbContext : DbContext
{
    public CompanyWebcastDbContext(DbContextOptions<CompanyWebcastDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Forecast> Forecasts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyWebcastDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}