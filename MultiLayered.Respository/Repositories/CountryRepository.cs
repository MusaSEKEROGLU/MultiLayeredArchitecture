using Microsoft.EntityFrameworkCore;
using MultiLayered.Core.Models;
using MultiLayered.Core.Repositories;
using MultiLayered.Respository.Contexts;

namespace MultiLayered.Respository.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Country> GetSingleCountryByIdWithTeamsAsync(int countryId)
        {
            return await _context.Countries.Include(x => x.Teams).Where(x => x.Id == countryId).SingleOrDefaultAsync();
        }
    }
}
