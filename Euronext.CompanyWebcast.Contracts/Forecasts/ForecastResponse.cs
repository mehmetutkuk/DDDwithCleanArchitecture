namespace Euronext.CompanyWebcast.Contracts.Forecasts;

public record ForecastResponse(
    string Id,
    string WeathermanId,
    DateTime ForecastDateTime,
    decimal Celsius,
    string WeatherStatus
);
