using AutoMapper;
using UdemyBackend.DTOs;
using UdemyBackend.Models;
using UdemyBackend.Repository;

namespace UdemyBackend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;

        public BeerService(IRepository<Beer> beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();
            return beers.Select(beer => _mapper.Map<BeerDto>(beer));
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }
            return null;
        }

        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            // A partir de beerInsertDto se necesita un Beer
            var beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRepository.Add(beer);
            // Con esta instrucción los datos se guardan en la db
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDto>(beer);
            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer != null)
            {
                // Editar el objeto existente
                beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer);
                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }
            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);
                _beerRepository.Delete(beer);
                await _beerRepository.Save();
                return beerDto;
            }
            return null;
        }
    }
}
