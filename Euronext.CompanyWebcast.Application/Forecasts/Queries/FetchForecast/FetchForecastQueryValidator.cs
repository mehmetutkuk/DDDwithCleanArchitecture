using Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;
using FluentValidation;

namespace Euronext.CompanyWebcast.Application.Forecasts.Queries.CreateForecast;

public class FetchForecastQueryValidator : AbstractValidator<FetchForecastQuery>
{
    public FetchForecastQueryValidator()
    {
    }
}