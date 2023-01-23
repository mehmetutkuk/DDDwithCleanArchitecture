using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using Euronext.CompanyWebcast.Domain.ForecastAggregate.ValueObjects;

namespace Euronext.CompanyWebcast.Tests.Domain;

public class ForecastDomaintest
{

    public ForecastDomaintest() { }

    [Fact]
    public void ForecastDomainCreateTest_ShouldBeSuccess()
    {
        var forecast =  Forecast.Create(WeathermanId.Create("ss"), DateTime.Now, Convert.ToDecimal(34.4));

        decimal expectedCelcius = Convert.ToDecimal(34.4);

        Assert.NotNull(forecast);
        Assert.Equal(expectedCelcius, forecast.DegreesCelsius);
    }
}