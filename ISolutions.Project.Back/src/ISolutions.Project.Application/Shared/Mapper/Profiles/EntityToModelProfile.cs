using AutoMapper;
using ISolutions.Project.Application.Features.User.Models;
using ISolutions.Project.Domain.Entities;

namespace ISolutions.Project.Application.Shared.Mapper.Profiles;
public class EntityToModelProfile : Profile
{
    public EntityToModelProfile()
    {
        CreateMap<UserEntitiy, UserModel>();
    }
}
