using BaseBackend.Domain;
using BaseBackend.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Infrastructure.Persistence;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly BaseContext _context;
    private readonly DbSet<TEntity> _entities;


    public GenericRepository(BaseContext dbContext)
    {
        _context = dbContext;
        _entities = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(CancellationToken token = default) => _entities.AsQueryable();
    public async Task<TEntity> FindAsync(object key, CancellationToken token = default)
        => await _entities.FindAsync(key, token);

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        => (await _entities.AddAsync(entity, token)).Entity;

    public void Update(TEntity entity) => _entities.Update(entity);
    public void Remove(TEntity entity) => _entities.Remove(entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

}
