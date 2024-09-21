using Microsoft.AspNetCore.Mvc;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeoples() => Repository.People;

        [HttpGet("{id}")]
        // ActionResult permite indicar que podemos devolver varios tipos de respuestas
        public ActionResult<People> GetPeople(int id)
        {
            // FirstOrDefault en caso de no existir devuelve null
            var people = Repository.People.FirstOrDefault(people => people.Id == id);
            if (people == null) return NotFound();
            return Ok(people);
        }

        // Sobrecarga: se pueden tener métodos con el mismo nombre pero con diferentes parámetros
        [HttpGet("search/{search}")]
        public List<People> GetPeople(string search) => Repository.People.Where(people => people.Name.ToLower().Contains(search.ToLower())).ToList();

        [HttpPost]
        // la interface IActionResult nos da más flexibilidad que la clase ActionResult
        public IActionResult Add(People people)
        {
            if (string.IsNullOrEmpty(people.Name)) return BadRequest();
            Repository.People.Add(people);
            // Se indica que todo salio ok pero no se devuelve nada
            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People() { Id = 1, Name = "Belu", Birthdate = new DateTime(1999, 12, 12) },
            new People() { Id = 2, Name = "Seba", Birthdate = new DateTime(1989, 01, 01) },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
