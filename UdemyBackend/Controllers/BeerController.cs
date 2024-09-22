using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyBackend.DTOs;
using UdemyBackend.Models;

namespace UdemyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;

        public BeerController
        (
            StoreContext context,
            IValidator<BeerInsertDto> beerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator
        )
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() => await _context.Beers.Select(beer => new BeerDto
        {
            Id = beer.Id,
            Name = beer.Name,
            Alcohol = beer.Alcohol,
            BrandId = beer.BrandId,
        }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null) return NotFound();
            var beerDto = new BeerDto
            {
                Id = beer.Id,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };
            return Ok(beerDto);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                Alcohol = beerInsertDto.Alcohol,
                BrandId = beerInsertDto.BrandId
            };

            await _context.Beers.AddAsync(beer);
            // Con esta instrucción los datos se guardan en la db
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.Id,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            // Primer parámetro es la ruta para obtener el recurso (aplicado en el header como Location)
            // El segundo es el dato que necesita el primer recurso
            // Y el último es la respuesta que irá en el body
            return CreatedAtAction(nameof(GetById), new { id = beer.Id }, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var beer = await _context.Beers.FindAsync(id);
            if (beer == null) return NotFound();

            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.Id,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null) return NotFound();
            _context.Remove(beer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
