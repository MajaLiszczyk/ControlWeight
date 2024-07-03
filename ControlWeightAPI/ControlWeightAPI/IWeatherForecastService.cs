
namespace ControlWeightAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}