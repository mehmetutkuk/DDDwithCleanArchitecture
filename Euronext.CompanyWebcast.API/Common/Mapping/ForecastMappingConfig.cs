using Euronext.CompanyWebcast.Application.Forecasts.Commands.CreateForecast;
using Euronext.CompanyWebcast.Application.Forecasts.Common;
using Euronext.CompanyWebcast.Application.Forecasts.Queries.CreateForecast;
using Euronext.CompanyWebcast.Contracts.Forecasts;
using Euronext.CompanyWebcast.Domain.ForecastAggregate;
using Mapster;

namespace Euronext.CompanyWebcast.API.Common.Mapping
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