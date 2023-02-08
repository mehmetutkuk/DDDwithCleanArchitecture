using  DDDOA.SolutionTemplate.Domain.Common.Models;

namespace DDDOA.SolutionTemplate.Domain.ForecastAggregate.ValueObjects;
public sealed class WeathermanId : ValueObject
{
    private WeathermanId(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static WeathermanId Create(string weathermanId)
    {
        return new WeathermanId(weathermanId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}