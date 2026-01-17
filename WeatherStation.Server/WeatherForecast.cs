namespace WeatherStation.Server;

public class WeatherForecast
{
    // { get; set; } is called "Auto-Properties"
    // If you remove { get; set; }, you turn a Property into a Field.
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}