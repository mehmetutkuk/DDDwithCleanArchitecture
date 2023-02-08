
using ErrorOr;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate;
using MediatR;

namespace DDDOA.SolutionTemplate.Application.Forecasts.Commands.CreateForecast;

public record CreateForecastCommand(
    string WeathermanId, DateTime ForecastDateTime, decimal Celsius) : IRequest<ErrorOr<Forecast>>;

