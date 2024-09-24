using AutoMapper;
using UdemyBackend.DTOs;
using UdemyBackend.Models;

namespace UdemyBackend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<Beer, BeerDto>();
            // En caso que algún campo no coincida se hace el mapeo para sincronizar nombres
            // suponiendo que el nombre del campo id fuera distinto entre las clases
            // se hace la siguiente transformación:
            // CreateMap<Beer, BeerDto>().ForMember
            // (
            //     dto => dto.Id,
            //     m => m.MapFrom(b => b.beerId)
            // );
            CreateMap<BeerUpdateDto, Beer>();
        }
    }
}
