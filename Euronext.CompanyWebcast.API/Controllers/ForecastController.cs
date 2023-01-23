using Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;
using Euronext.CompanyWebcast.Application.Forecasts.Common;
using Euronext.CompanyWebcast.Application.Forecasts.Queries.CreateForecast;
using Euronext.CompanyWebcast.Contracts.Forecasts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Euronext.CompanyWebcast.API.Controllers;

[Route("api/[controller]")]
public class ForecastsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ForecastsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateForecast(
        CreateForecastRequest request,
        string weathermanId)
    {
        var command = _mapper.Map<CreateForecastCommand>((request, weathermanId));

        var createForecastResult = await _mediator.Send(command);

        return createForecastResult.Match(
            forecast => Ok(_mapper.Map<ForecastResponse>(forecast)),
            errors => Problem(errors));
    }
        
    [HttpGet]
    public async Task<IActionResult> FetchWeeklyForecast()
    {
        var request = new FetchWeeklyForecastRequest(DateTime.Now);

        var query = _mapper.Map<FetchForecastQuery>((request));

        var fetchWeeklyForecastResult = await _mediator.Send(query);

        return fetchWeeklyForecastResult.Match(
            weeklyForecast => Ok(_mapper.Map<ForecastWeeklyResult>(weeklyForecast)),
            errors => Problem(errors));
    }
}