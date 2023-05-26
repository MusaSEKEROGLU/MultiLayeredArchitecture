using MultiLayered.Core.Models;

namespace MultiLayered.Core.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetSingleCountryByIdWithTeamsAsync(int countryId);
    }
}
