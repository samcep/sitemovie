using AutoMapper;
using sitemovie.DTO;
using sitemovie.Entities;

namespace sitemovie.Helpers.AutoMapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Genre ,GenreDto>().ReverseMap();
            CreateMap<GenreCreateDto, Genre>();
        }
    }
}
