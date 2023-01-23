namespace Euronext.CompanyWebcast.Contracts.Forecasts;

public record FetchWeeklyForecastRequest(
    DateTime forecastDateTime);