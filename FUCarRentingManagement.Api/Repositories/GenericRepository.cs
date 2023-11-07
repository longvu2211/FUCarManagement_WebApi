using FUCarRentingManagement.Infrastructure;
using FUCarRentingManagement.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FUCarRentingManagement.Api.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly FucarRentingManagementContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(FucarRentingManagementContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }
        
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.Where(x => true);
        }

        public async Task<TEntity> GetById(object id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(params TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
