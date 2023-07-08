namespace BaseBackend.Domain;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> GetAll(CancellationToken token = default);
    public Task<TEntity> FindAsync(object key, CancellationToken token = default);
    public Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
    public void Update(TEntity entity);
    public void Remove(TEntity entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
