using Microsoft.EntityFrameworkCore;
using MultiLayered.Core.Models;
using MultiLayered.Core.Repositories;
using MultiLayered.Respository.Contexts;

namespace MultiLayered.Respository.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context)
        {
        }

        //Takımlarla birlikte ülkeleride getir = Include => Eager Loading
        public async Task<List<Team>> GetTeamsWithCountryAsync()
        {
            return await _context.Teams.Include(x => x.Country).ToListAsync();
        }
    }
}
