using FluentValidation;

namespace Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;

public class CreateForecastCommandValidator : AbstractValidator<CreateForecastCommand>
{
    public CreateForecastCommandValidator()
    {
        RuleFor(x => x.WeathermanId).NotEmpty();
        RuleFor(x => x.ForecastDateTime).NotEmpty();
        RuleFor(x => x.ForecastDateTime).Must(x => x.Kind == DateTimeKind.Utc).WithMessage("ForecastDateTime must be in UTC format");
        RuleFor(x => x.ForecastDateTime).Must(x=> x>= DateTime.Now).WithMessage("ForecastDateTime must be in the future");
        RuleFor(x => x.Celsius).NotEmpty();
        RuleFor(x => x.Celsius).Must(x => x >= -60).WithMessage("Celsius must be greater than -60");
        RuleFor(x => x.Celsius).Must(x => x <= 60).WithMessage("Celsius must be less than 60");
    }
}