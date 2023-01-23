namespace Euronext.CompanyWebcast.Contracts.Forecasts;

public record FetchWeeklyForecastResponse(
    DateTime ForecastDateTime,
    decimal Celsius,
    string WeatherStatus
);