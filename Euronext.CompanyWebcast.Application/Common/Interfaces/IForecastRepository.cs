using Euronext.CompanyWebcast.Application.Forecasts.Common;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;

namespace Euronext.CompanyWebcast.Application.Common.Interfaces;

public interface  IForecastRepository
{
    Task Add(Forecast forecast);
    Task<IEnumerable<ForecastResult>> FetchWeeklyForecast(DateTime forecastDateTime, CancellationToken cancellationToken);
    Task<bool> CheckForecastIsExist(DateTime forecastDateTime, CancellationToken cancellationToken);
}