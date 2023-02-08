namespace DDDOA.SolutionTemplate.Contracts.Forecasts;

public record ForecastResponse(
    string Id,
    string WeathermanId,
    DateTime ForecastDateTime,
    decimal Celsius,
    string WeatherStatus
);
