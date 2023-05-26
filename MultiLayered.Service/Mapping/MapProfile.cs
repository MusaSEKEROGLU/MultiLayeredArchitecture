using AutoMapper;
using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;

namespace MultiLayered.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<Team, TeamDto>().ReverseMap();

            CreateMap<TeamFeature, TeamFeatureDto>().ReverseMap();

            CreateMap<TeamUpdateDto, Team>();

            CreateMap<Team, TeamWithCountryDto>();

            CreateMap<Country, CountryWithTeamsDto>();
        }
    }
}
