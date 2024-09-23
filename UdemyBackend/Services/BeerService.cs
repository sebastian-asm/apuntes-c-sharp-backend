using Microsoft.EntityFrameworkCore;
using UdemyBackend.DTOs;
using UdemyBackend.Models;

namespace UdemyBackend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerDto>> Get() => await _context.Beers.Select(beer => new BeerDto
        {
            Id = beer.Id,
            Name = beer.Name,
            Alcohol = beer.Alcohol,
            BrandId = beer.BrandId,
        }).ToListAsync();

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId,
                };
                return beerDto;
            }
            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
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

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer != null)
            {
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
                return beerDto;
            }
            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId
                };

                _context.Remove(beer);
                await _context.SaveChangesAsync();
                return beerDto;
            }
            return null;
        }
    }
}
