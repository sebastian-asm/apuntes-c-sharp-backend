using Microsoft.AspNetCore.Mvc;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpPost]
        // [FromHeader] para obtener información de los headers de la petición
        public decimal Add(Numbers numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength, [FromHeader(Name = "x-token")] string Token)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            Console.WriteLine(Token);
            return numbers.A + numbers.B;
        }
    }

    public class Numbers
    {
        public int A { get; set; }
        public int B { get; set; }
    }
}
