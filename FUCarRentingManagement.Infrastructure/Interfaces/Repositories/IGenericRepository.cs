using System.Linq.Expressions;

namespace FUCarRentingManagement.Infrastructure.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Get(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

        Task<TEntity> GetById(object id, CancellationToken cancellationToken = default);

        Task Add(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Remove(TEntity entity);

        void RemoveRange(params TEntity[] entities);

        void Update(TEntity entity);

        void UpdateRange(params TEntity[] entities);

        Task Save(CancellationToken cancellationToken = default);
    }
}
