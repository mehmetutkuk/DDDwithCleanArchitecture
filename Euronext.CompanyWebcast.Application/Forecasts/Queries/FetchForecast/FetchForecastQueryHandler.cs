
using ErrorOr;
using Euronext.CompanyWebcast.Application.Common.Interfaces;
using Euronext.CompanyWebcast.Application.Forecasts.Common;
using MediatR;


namespace Euronext.CompanyWebcast.Application.Forecasts.Queries.CreateForecast;


public class FetchForecastQueryHandler :
  IRequestHandler<FetchForecastQuery, ErrorOr<ForecastWeeklyResult>>
{
    private readonly IForecastRepository _forecastRepository;

    public FetchForecastQueryHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public async Task<ErrorOr<ForecastWeeklyResult>> Handle(
        FetchForecastQuery request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = await _forecastRepository.FetchWeeklyForecast(request.ForecastDateTime, cancellationToken);

        return new ForecastWeeklyResult(result);
    }


}