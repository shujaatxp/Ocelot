using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sensor.Publisher
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        public readonly IWeatherDataPublisher weatherDataPublisher;

        public SensorController(IWeatherDataPublisher weatherDataPublisher)
        {
            this.weatherDataPublisher = weatherDataPublisher;
        }

        [HttpPost]
        public async Task Post([FromBody] Weather weather)
        {
            await weatherDataPublisher.ProduceAsync(weather);
        }
    }
}
