
using ErrorOr;
using Euronext.CompanyWebcast.Application.Common.Interfaces;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using Euronext.CompanyWebcast.Domain.ForecastAggregate.ValueObjects;
using MediatR;


namespace Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;


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