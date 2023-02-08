using Ardalis.SmartEnum;

namespace DDDOA.SolutionTemplate.Domain.ForecastAggregate.Enums
{
    public class WeatherStatus : SmartEnum<WeatherStatus>
    {

        public WeatherStatus(string name, int value) : base(name, value) { }
        public static readonly WeatherStatus Freezing = new(nameof(Freezing), 1);
        public static readonly WeatherStatus Bracing = new(nameof(Bracing), 2);
        public static readonly WeatherStatus Chilly = new(nameof(Chilly), 3);
        public static readonly WeatherStatus Cool = new(nameof(Cool), 4);
        public static readonly WeatherStatus Mild = new(nameof(Mild), 5);
        public static readonly WeatherStatus Warm = new(nameof(Warm), 6);
        public static readonly WeatherStatus Balmy = new(nameof(Balmy), 7);
        public static readonly WeatherStatus Hot = new(nameof(Hot), 8);
        public static readonly WeatherStatus Sweltering = new(nameof(Sweltering), 9);

    }
}