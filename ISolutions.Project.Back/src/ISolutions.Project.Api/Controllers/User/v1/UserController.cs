using Asp.Versioning;
using ISolutions.Project.Application.Features.User.Models;
using ISolutions.Project.Application.Features.User.Queries;
using ISolutions.Project.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ISolutions.Project.Api.Controllers.User.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(
        ILogger<UserController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [MapToApiVersion("1.0")]
    [HttpGet("{pagenumber}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Sucesso: Objeto de retorno de requisição", typeof(UsersModel))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Register not found: nenhum registro encontrado")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Algum parâmetro não informado ou pelo menos uma regra de negócio não foi atendida. (BadRequest)")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Acesso negado. Username ou password não informados ou inválidos. (Unauthorized)")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Acesso negado. Sem permissão de acesso a funcionalidade. (Forbidden)")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro não tratado encontrado. (Internal Server Error)")]
    public async Task<IActionResult> GetPaginationUsersAsnc(
        [FromRoute][Required] int pagenumber,
        [FromQuery] int? pagesize,
        CancellationToken cancellationToken)
    {
        try
        {
            using (_logger.BeginScope(new Dictionary<string, object>
            {
                ["Controller"] = nameof(UserController),
                ["PageNumber"] = pagenumber
            }))
            {
                _logger.LogDebug("Start {0} - {1} with page: {2}", nameof(UserController), nameof(GetPaginationUsersAsnc), pagenumber);
            }

            var result = await _mediator.Send(new GetUsersQuery(pagenumber, pagesize), cancellationToken);

            if (result.ResponseType == ResponseType.NotFound)
                return NoContent();

            if (result.ResponseType == ResponseType.BadRequest)
                return BadRequest(result.Errors);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
