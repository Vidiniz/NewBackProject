using ISolutions.Project.Domain.Entities;
using ISolutions.Project.Infrastructure.Database.Context;
using ISolutions.Project.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISolutions.Project.Infrastructure.Repositories.Implementations;
public class UserRepository :  BaseRepository<UserEntitiy>, IUserRepository
{
    public UserRepository(SolutionsContext context): base(context)
    {
    }

    public async Task<long> GetTotalUsersAsync(CancellationToken cancellationToken)
    {
        return await _context.Users.CountAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserEntitiy>> GetUsersByPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking()
                             .OrderBy(x => x.Id)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }
}
