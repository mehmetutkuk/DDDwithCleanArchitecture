
using ErrorOr;
using DDDOA.SolutionTemplate.Application.Forecasts.Common;
using MediatR;

namespace DDDOA.SolutionTemplate.Application.Forecasts.Queries.CreateForecast;

public record FetchForecastQuery(
    DateTime ForecastDateTime) : IRequest<ErrorOr<ForecastWeeklyResult>>;

