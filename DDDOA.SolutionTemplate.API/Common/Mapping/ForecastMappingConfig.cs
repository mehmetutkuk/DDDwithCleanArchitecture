using DDDOA.SolutionTemplate.Application.Forecasts.Commands.CreateForecast;
using DDDOA.SolutionTemplate.Application.Forecasts.Common;
using DDDOA.SolutionTemplate.Application.Forecasts.Queries.CreateForecast;
using DDDOA.SolutionTemplate.Contracts.Forecasts;
using DDDOA.SolutionTemplate.Domain.ForecastAggregate;
using Mapster;

namespace DDDOA.SolutionTemplate.API.Common.Mapping
{
    public class ForecastMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateForecastRequest Request, string WeathermanId), CreateForecastCommand>()
                .Map(dest => dest.WeathermanId, src => src.WeathermanId)
                .Map(dest => dest.Celsius, src => src.Request.celsius)
                .Map(dest => dest.ForecastDateTime, src => src.Request.forecastDateTime);

            config.NewConfig<Forecast, ForecastResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.WeathermanId, src => src.WeathermanId.Value)
                .Map(dest => dest.ForecastDateTime, src => src.ForecastDateTime)
                .Map(dest => dest.Celsius, src => src.DegreesCelsius)
                .Map(dest => dest.WeatherStatus, src => src.WeatherStatus);

            config.NewConfig<Forecast, ForecastResult>()
                .Map(dest => dest.Celsius, src => src.DegreesCelsius)
                .Map(dest => dest.WeathermanId, src => src.WeathermanId.Value)
                .Map(dest => dest.ForecastDateTime, src => src.ForecastDateTime)
                .Map(dest => dest.WheatherStatus, src => src.WeatherStatus);

            config.NewConfig<FetchWeeklyForecastRequest, FetchForecastQuery>()
                .Map(dest => dest.ForecastDateTime, src => src.forecastDateTime);
  
            config.NewConfig<FetchForecastQuery, ForecastWeeklyResult>();
        }
    }
}