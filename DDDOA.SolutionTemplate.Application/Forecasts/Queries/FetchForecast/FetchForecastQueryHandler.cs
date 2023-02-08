
using ErrorOr;
using DDDOA.SolutionTemplate.Application.Common.Interfaces;
using DDDOA.SolutionTemplate.Application.Forecasts.Common;
using MediatR;

namespace DDDOA.SolutionTemplate.Application.Forecasts.Queries.CreateForecast;


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