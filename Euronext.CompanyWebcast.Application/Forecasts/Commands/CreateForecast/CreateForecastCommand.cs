
using ErrorOr;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using MediatR;

namespace Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;

public record CreateForecastCommand(
    string WeathermanId, DateTime ForecastDateTime, decimal Celsius) : IRequest<ErrorOr<Forecast>>;

