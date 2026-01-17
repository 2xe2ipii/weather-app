namespace WeatherStation.Server;

public class WeatherForecast
{
    // { get; set; } is called "Auto-Properties"
    // If you remove { get; set; }, you turn a Property into a Field.
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}

/*
I see the JSON in my browser. However, I still have many questions. I'll categorize my questions for each file.

A. WeatherForecast.cs (Model)

1. Why is "namespace WeatherStation.Server" needed? Please explain fundamentally. Why did the developers of .NET Core or C# thought this is necessary for everything to work. Show me the scenario if we didn't have it.

2. In my Kino project, if I remember correctly, the models are compiled inside a folder called "Models". In that case, do we have to change the namespace into "namespace WeatherStation.Server.Models"? Moreover, can I only have one class per model file?

3. Why is TemperatureC assigned as an integer when we know that temperature can be fuzzy?

4. What is { get; set; }? If I remember correctly, I would create a private variable, then, inside the same class, I would have a public method that has read-only access to that private variable just so other classes can see the content of that variable without changing it. Then, I remember learning that there is a more concise way of doing that which is { get; private set; } which lets me access the content of that variable, but doesn't allow me to change it. However, here, we have { get; set; } and I'm assuming these are all public?

5. Why is string the only(?) variable that cannot take null values? Why do we not have to add a "?" in the int or Date type variables?

B. WeatherController.cs (Controller)

1. What is "using Microsoft.AspNetCore.Mvc"? Please explain fundamentally. Why did the developers of .NET Core or C# thought this is necessary for everything to work. Show me the scenario if we didn't have it.

2. The namespace is only within "WeatherStation.Server.Controllers", does this mean that this can only be accessed by other files or classes within that same scope? So, "WeatherForecast.cs" doesn't have access to this controller?

3. What exactly is [ApiController]? Do we need this everytime we create a controller file?

4. You mentioned that ("api/[controller]") automatically names the route with the class name minus the word "controller", it changes it lowercase as well? Tell me more.

5. "WeatherController : ControllerBase", this is inheritance, right? What exactly do we inherit? Also, I notice that we [HttpGet] above a public method, I tried adding "[HttpPost]" under it but no errors appeared in the code (haven't ran it yet). Why is that? What's happening?

6. What is an IEnumerable? Is it like a list? Tell me more about "public IEnumerable<WeatherForecast> Get()" I don't quite understand this syntax, there is no method name at all. I do see that this could mean: "Get a list of weather forecasts.". However, how do we call this if there is no method name?

7. Moreover, how do we have access to "WeatherForecast" when it's from a different namespace? This refers to the Model, right?

8. Since I have [HttpPost] under [HttpGet], what will Get() do?

C. Program.cs

1. You forgot to discuss what Program.cs is. I want to understand every single line of code here. Correct me if I'm wrong but I'm pretty sure that this serves as the entry point when we run the server, right? 

2. Discuss other important files in the server side.

Answer all this questions, then we'll revise if we need to revise anything. After that, we'll update the README.md.
*/