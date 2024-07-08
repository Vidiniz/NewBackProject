using ISolutions.Project.Application.Shared.Models;

namespace ISolutions.Project.Application.Features.User.Models;
public class UsersModel : BaseModel
{
    public IEnumerable<UserModel>? Users { get; set; }
    public long TotalRecords { get; set; }
}
