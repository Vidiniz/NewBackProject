using AutoMapper;
using ISolutions.Project.Application.Features.User.Models;
using ISolutions.Project.Application.Features.User.Queries;
using ISolutions.Project.Domain.Configurations;
using ISolutions.Project.Domain.Enums;
using ISolutions.Project.Domain.Messages;
using ISolutions.Project.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ISolutions.Project.Application.Features.User.Handlers;
public class GetUsersHandler : IRequestHandler<GetUsersQuery, UsersModel>
{
    private readonly ILogger<GetUsersHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly PaginationConfiguration _configuration;

    public GetUsersHandler(
        ILogger<GetUsersHandler> logger, 
        IUserRepository userRepository,
        IMapper mapper,
        IOptions<PaginationConfiguration> options)
    {
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = options.Value;
    }

    public async Task<UsersModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var result = new UsersModel();
        try
        {
            var pageSize = GetPageSize(request.PageSize);
            var users = await _userRepository.GetUsersByPaginationAsync(request.PageNumber, pageSize, cancellationToken);

            if (users is null)
            {
                _logger.LogError("[{0}] Erro ao obter registros de usuarios", nameof(GetUsersHandler));

                result.SetResponse(ApplicationsResultMessages.DefaultErrorMessage, ResponseType.NotFound);
                return result;
            }

            result.TotalRecords = await _userRepository.GetTotalUsersAsync(cancellationToken);
            result.Users = _mapper.Map<IEnumerable<UserModel>>(users);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[{0}] Error to get users list", nameof(GetUsersHandler));

            result.SetResponse(ApplicationsResultMessages.DefaultErrorMessage, ResponseType.BadRequest);
            return result;
        }
    }

    private int GetPageSize(int? pageSize)
    {
        int localPageSize = _configuration!.DefaultPageSize;

        if (pageSize is not null
            && pageSize <= _configuration.MaxPageSize
            && pageSize >= _configuration.MinPageSize)
            localPageSize = pageSize.Value;

        return localPageSize;
    }
}
