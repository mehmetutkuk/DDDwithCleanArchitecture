using DDDOA.SolutionTemplate.Application.Forecasts.Common;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate;

namespace DDDOA.SolutionTemplate.Application.Common.Interfaces;

public interface  IForecastRepository
{
    Task Add(Forecast forecast);
    Task<IEnumerable<ForecastResult>> FetchWeeklyForecast(DateTime forecastDateTime, CancellationToken cancellationToken);
    Task<bool> CheckForecastIsExist(DateTime forecastDateTime, CancellationToken cancellationToken);
}