using ISolutions.Project.Domain.Entities;
namespace ISolutions.Project.Infrastructure.Repositories.Interfaces;

public interface IUserRepository: IBaseRepository<UserEntitiy>
{
    Task<IEnumerable<UserEntitiy>> GetUsersByPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<long> GetTotalUsersAsync(CancellationToken cancellationToken);
}
