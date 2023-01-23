using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using Euronext.CompanyWebcast.Domain.ForecastAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euronext.CompanyWebcast.Insfrastructure.Persistence.Configurations;


public class ForecastConfigurations : IEntityTypeConfiguration<Forecast>

{
    public void Configure(EntityTypeBuilder<Forecast> builder)
    {
            ConfigureForecastsTable(builder);   
    }


     private void ConfigureForecastsTable(EntityTypeBuilder<Forecast> builder)
    {
        builder.ToTable("Forecasts");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ForecastId.Create(value));

        builder.Property(m => m.WeathermanId)
            .HasConversion(
                id => id.Value,
                value => WeathermanId.Create(value));
    }
}