using AutoMapper;
using FluentValidation;
using ISolutions.Project.Application.Features.User.Commands;
using ISolutions.Project.Application.Shared.Models;
using ISolutions.Project.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISolutions.Project.Application.Features.User.Handlers;
public class AddUserHandler : IRequestHandler<AddUserCommand, BaseModel>
{
    private readonly ILogger<AddUserHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<AddUserCommand> _validator;

    public Task<BaseModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
