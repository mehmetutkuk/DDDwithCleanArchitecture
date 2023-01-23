using Euronext.CompanyWebcast.Domain.Common.Models;
namespace Euronext.CompanyWebcast.Domain.ForecastAggregate.ValueObjects;

public sealed class ForecastId : ValueObject
{
    public Guid Value { get; private set; }

    private ForecastId(Guid value)
    {
        Value = value;
    }

    public static ForecastId CreateUnique()
    {
        // TODO: enforce invariants
        return new ForecastId(Guid.NewGuid());
    }

    public static ForecastId Create(Guid value)
    {
        // TODO: enforce invariants
        return new ForecastId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}