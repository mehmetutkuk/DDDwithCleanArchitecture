namespace DDDOA.SolutionTemplate.Contracts.Forecasts;

public record CreateForecastRequest(
    DateTime forecastDateTime,
    decimal celsius);