using MultiLayered.Core.Models;

namespace MultiLayered.Core.Repositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<List<Team>> GetTeamsWithCountryAsync();
    }
}
