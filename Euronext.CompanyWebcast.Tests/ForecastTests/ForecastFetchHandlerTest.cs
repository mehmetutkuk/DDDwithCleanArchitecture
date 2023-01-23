using Euronext.CompanyWebcast.Application.Common.Interfaces;
using Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using MediatR;
using Moq;

namespace Euronext.CompanyWebcast.Tests.ForecastTests;

public class ForecastFetchHandlerTest
{

    [Fact]
    public async Task TestHandler_Default()
    {

        var mediator = new Mock<IMediator>();

        var resposity =new Mock<IForecastRepository>();
        CreateForecastCommand command = new CreateForecastCommand("sd",DateTime.Now,Convert.ToDecimal(23.4));
        CreateForecastCommandHandler handler = new CreateForecastCommandHandler(resposity.Object);

        //Act
        var x = await handler.Handle(command, new System.Threading.CancellationToken());

        //Assert
        Assert.True(!x.IsError);
        Assert.Equal("Chilly", x.Value.WeatherStatus);
    }

   
}