
using ErrorOr;
using DDDOA.SolutionTemplate.Application.Common.Interfaces;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate.ValueObjects;
using MediatR;


namespace DDDOA.SolutionTemplate.Application.Forecasts.Commands.CreateForecast;


public class CreateForecastCommandHandler : IRequestHandler<CreateForecastCommand, ErrorOr<Forecast>>
{
    private readonly IForecastRepository _forecastRepository;

    public CreateForecastCommandHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public async Task<ErrorOr<Forecast>> Handle(CreateForecastCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var isExist = await _forecastRepository.CheckForecastIsExist(request.ForecastDateTime, cancellationToken);
        if(isExist)
            return Error.Validation(description: $"Forecast for {request.ForecastDateTime.Date} already exist");
        var forecast = Forecast.Create(
            weathermanId: WeathermanId.Create(request.WeathermanId),
            forecastDateTime: request.ForecastDateTime,
            degreesCelsius: request.Celsius
          );

        await _forecastRepository.Add(forecast);

        return forecast;
    }
}