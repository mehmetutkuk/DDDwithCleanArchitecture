using DDDOA.SolutionTemplate.Application.Forecasts.Commands.CreateForecast;
using FluentValidation;

namespace DDDOA.SolutionTemplate.Application.Forecasts.Queries.CreateForecast;

public class FetchForecastQueryValidator : AbstractValidator<FetchForecastQuery>
{
    public FetchForecastQueryValidator()
    {
    }
}