using ISolutions.Project.Infrastructure.Database.Context;
using ISolutions.Project.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISolutions.Project.Infrastructure.Repositories.Implementations;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected SolutionsContext _context;

    public BaseRepository(SolutionsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity obj, CancellationToken cancellationToken) => await _context.Set<TEntity>().AddAsync(obj, cancellationToken);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(int pageNumber, int recordNumbers)
    {
        var result = _context.Set<TEntity>();

        var skip = (pageNumber - 1) * recordNumbers;

        await result.Skip(skip).Take(recordNumbers).ToListAsync();

        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) => await _context.Set<TEntity>().FindAsync(id, cancellationToken);
    public void Remove(TEntity obj) => _context.Set<TEntity>().Remove(obj);
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken) => (await _context.SaveChangesAsync(cancellationToken)) <= 0;
    public void Update(TEntity obj) => _context.Entry(obj).State = EntityState.Modified;

}
