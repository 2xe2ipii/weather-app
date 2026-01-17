using Microsoft.AspNetCore.Mvc;
using WeatherStation.Server;

namespace WeatherStation.Server.Controllers;

[ApiController] // Hey, this class isn't just normal code. It's an HTTP API. Please add automatic validation and error handling.
[Route("api/[controller]")] // This defines the URL. [controller] is a variable that is replaced by the class name (minus "Controller").
// Class: WeatherController -> URL: api/weather

// [controller] here is called a "Route Token"
public class WeatherController : ControllerBase
{
    // GET: api/weather
    [HttpGet]
    [HttpPost]
    public IEnumerable<WeatherForecast> Get()
    {
        return new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 30,
                Summary = "Hot"
            },
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 25,
                Summary = "Pleasant"
            }
        };
    }
}