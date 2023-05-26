using System.Linq.Expressions;

namespace MultiLayered.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression); //teamRepository.where(x => x.id>5).OrderBy.ToListAync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); //var mı , yok mu
        Task AddAsync(T entity); //tekli ekleme
        Task AddRangeAsync(IEnumerable<T> entities); //çoklu ekleme
        void Update(T entity);
        void Remove(T entity);  //tekli silme
        void RemoveRange(IEnumerable<T> entities);  //çoklu silme
    }
}
