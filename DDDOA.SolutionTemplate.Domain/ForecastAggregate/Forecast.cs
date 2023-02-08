using DDDOA.SolutionTemplate.Domain.Common.Models;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate.Enums;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate.ValueObjects;

namespace DDDOA.SolutionTemplate.Domain.ForecastAggregate;


public sealed class Forecast : AggregateRoot<ForecastId>
{
    public DateTime ForecastDateTime { get; private set; }
    public WeathermanId WeathermanId { get; private set; }
    public decimal DegreesCelsius { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public string WeatherStatus
    {
        get
        {
            switch (DegreesCelsius)
            {
                default:
                case < 0:
                    return "Freezing";
                case < 15:
                    return "Bracing";
                case < 25:
                    return "Chilly";
                case < 30:
                    return "Cool";
                case < 35:
                    return "Mild";
                case < 40:
                    return "Warm";
                case < 45:
                    return "Balmy";
                case < 50:
                    return "Hot";
                case >= 50:
                    return "Sweltering";
            };
        }
        private set {}
    }

    private Forecast(
        ForecastId forecastId,
        WeathermanId weathermanId,
        DateTime forecastDateTime,
        decimal degreesCelsius)
        : base(forecastId)
    {
        WeathermanId = weathermanId;
        ForecastDateTime = forecastDateTime;
        DegreesCelsius = degreesCelsius;
    }

    public static Forecast Create(
        WeathermanId weathermanId, DateTime forecastDateTime, decimal degreesCelsius)
    {
        // TODO: enforce invariants
        return new Forecast(
            ForecastId.CreateUnique(),
                            weathermanId,
                            forecastDateTime,
                            degreesCelsius);
    }

#pragma warning disable CS8618
    private Forecast()
    {
    }
#pragma warning restore CS8618
}
