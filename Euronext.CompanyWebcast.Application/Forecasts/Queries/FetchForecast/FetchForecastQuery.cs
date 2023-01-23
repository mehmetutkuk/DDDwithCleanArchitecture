
using ErrorOr;
using Euronext.CompanyWebcast.Application.Forecasts.Common;
using MediatR;

namespace Euronext.CompanyWebcast.Application.Forecasts.Queries.CreateForecast;

public record FetchForecastQuery(
    DateTime ForecastDateTime) : IRequest<ErrorOr<ForecastWeeklyResult>>;

