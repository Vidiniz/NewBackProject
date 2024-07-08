namespace ISolutions.Project.Infrastructure.Repositories.Interfaces;
public interface IBaseRepository<TEntity>: IDisposable where TEntity : class
{
    Task AddAsync(TEntity obj, CancellationToken cancellationToken);

    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int recordNumbers);

    Task<IEnumerable<TEntity>> GetAllAsync();

    void Update(TEntity obj);

    void Remove(TEntity obj);

    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);

}
