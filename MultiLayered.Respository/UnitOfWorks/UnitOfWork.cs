using MultiLayered.Core.UnitOfWorks;
using MultiLayered.Respository.Contexts;

namespace MultiLayered.Respository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAscync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
