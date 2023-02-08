using DDDOA.SolutionTemplate.Application.Common.Interfaces;
using DDDOA.SolutionTemplate.Application.Forecasts.Common;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDDOA.SolutionTemplate.Insfrastructure.Persistence.Repositories;


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
        return await _dbContext.Forecasts
          .Where(s => s.ForecastDateTime >= forecastDateTime
          && s.ForecastDateTime <= endDate).Select(s => new ForecastResult(s.DegreesCelsius, s.WeathermanId.Value, s.ForecastDateTime, s.WeatherStatus)).ToListAsync(cancellationToken);
    }

    public async Task<bool> CheckForecastIsExist(DateTime forecastDateTime, CancellationToken cancellationToken)
    {
        return await _dbContext.Forecasts.AnyAsync(s => s.ForecastDateTime.Date == forecastDateTime.Date, cancellationToken);
    }
}