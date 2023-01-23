namespace Euronext.CompanyWebcast.Application.Forecasts.Common;


public record ForecastResult(decimal Celsius, string WeathermanId, DateTime ForecastDateTime, string WheatherStatus);

public record ForecastWeeklyResult(IEnumerable<ForecastResult> ForecastResult);