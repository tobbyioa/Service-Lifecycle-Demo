using Microsoft.AspNetCore.Mvc;
using SimpleApi.Services;
using SimpleApi.Services.Interfaces;

namespace SimpleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOperationTransient _transient;
     private readonly IOperationScoped _scoped;
      private readonly IOperationSingleton _singleton;

    public WeatherForecastController(
        IOperationTransient transient,
        IOperationScoped scoped,
        IOperationSingleton singleton,
        ILogger<WeatherForecastController> logger)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
         _logger.LogInformation($"Singleton: {_singleton.OperationId}");
          _logger.LogInformation($"Scoped: {_scoped.OperationId}");
           _logger.LogInformation($"Transient: {_transient.OperationId}");
        return Ok();
    }
}
