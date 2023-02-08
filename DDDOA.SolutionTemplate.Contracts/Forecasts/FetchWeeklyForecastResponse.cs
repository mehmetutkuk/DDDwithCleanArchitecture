namespace DDDOA.SolutionTemplate.Contracts.Forecasts;

public record FetchWeeklyForecastResponse(
    DateTime ForecastDateTime,
    decimal Celsius,
    string WeatherStatus
);