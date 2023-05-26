using MultiLayered.Core.Dtos;
using MultiLayered.Core.Models;

namespace MultiLayered.Core.Services
{
    public interface ICountryService : IGenericService<Country>
    {
        Task<CustomResponseDto<CountryWithTeamsDto>> GetSingleCountryByIdWithTeamsAsync(int countryId);
    }
}
