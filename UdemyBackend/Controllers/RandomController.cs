using Microsoft.AspNetCore.Mvc;
using UdemyBackend.Services;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;

        public RandomController([FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton, [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped, [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient)
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();
            result.Add("Singleton", _randomServiceSingleton.Value);
            result.Add("Scoped", _randomServiceScoped.Value);
            result.Add("SingletonTransient", _randomServiceTransient.Value);
            return result;
        }
    }
}
