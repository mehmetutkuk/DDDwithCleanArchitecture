namespace Euronext.CompanyWebcast.Contracts.Forecasts;

public record CreateForecastRequest(
    DateTime forecastDateTime,
    decimal celsius);