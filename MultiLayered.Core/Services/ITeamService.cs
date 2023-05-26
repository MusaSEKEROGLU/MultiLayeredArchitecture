using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;

namespace MultiLayered.Core.Services
{
    public interface ITeamService : IGenericService<Team>
    {
        //API yi kullanan MVC uygulaması için
        Task<CustomResponseDto<List<TeamWithCountryDto>>> GetTeamsWithCountryAsync();


        //Servisleri kullanan MVC uygulaması için
        //Task<List<TeamWithCountryDto>> GetTeamsWithCountryAsync();
    }
}
