using ISolutions.Project.Application.Features.User.Models;
using MediatR;

namespace ISolutions.Project.Application.Features.User.Queries;
public class GetUsersQuery: IRequest<UsersModel>
{
    public int PageNumber { get; set; }
    public int? PageSize { get; set; }

    public GetUsersQuery(int pageNumber, int? pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
