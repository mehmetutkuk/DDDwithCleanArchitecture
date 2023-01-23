using Euronext.CompanyWebcast.Application.Common.Interfaces;
using Euronext.CompanyWebcast.Application.Forecasts.Common;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using Microsoft.EntityFrameworkCore;

namespace Euronext.CompanyWebcast.Insfrastructure.Persistence.Repositories;


public class ForecastRepository : IForecastRepository
{
    private readonly CompanyWebcastDbContext _dbContext;

    public ForecastRepository(CompanyWebcastDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Forecast forecast)
    {
        _dbContext.Add(forecast);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ForecastResult>> FetchWeeklyForecast(DateTime forecastDateTime, CancellationToken cancellationToken)
    {
        var endDate = forecastDateTime.AddDays(7);
        var result = await _dbContext.Forecasts
          .Where(s => s.ForecastDateTime >= forecastDateTime
          && s.ForecastDateTime <= endDate).Select(s => new ForecastResult(s.DegreesCelsius, s.WeathermanId.Value, s.ForecastDateTime, s.WeatherStatus)).ToListAsync(cancellationToken);
    return result;
    }
}