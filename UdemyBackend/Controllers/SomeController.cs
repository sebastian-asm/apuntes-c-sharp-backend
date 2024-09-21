using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        // Operación sincránica
        public IActionResult Sync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Conexión a DB finalizada");
            Thread.Sleep(2000);
            Console.WriteLine("Envío de email finalizado");
            Console.WriteLine("¡Todo el proceso a fianlizado!");
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        // Operación asincrónica
        public async Task<IActionResult> Async()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Conexión a DB finalizada");
                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envío de email finalizado");
                return 2;
            });

            // Iniciar la tarea
            task1.Start();
            task2.Start();
            Console.WriteLine("Realizando otros procesos...");

            // Con await, esperará hasta terminar la tarea para seguir avanzando con la siguiente línea
            var result1 = await task1;
            var result2 = await task2;

            Console.WriteLine("¡Todo el proceso a fianlizado!");
            stopwatch.Stop();
            return Ok($"Resultado 1: {result1}, Resultado 2: {result2} | Tiempo total: {stopwatch.Elapsed}");
        }
    }
}
