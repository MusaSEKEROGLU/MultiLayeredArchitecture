
namespace MultiLayered.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAscync();
        void Commit();
    }
}
