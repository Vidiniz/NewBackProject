using ISolutions.Project.Api.Configurations;
using ISolutions.Project.Application.Shared.Mapper;
using ISolutions.Project.Application.Shared.Mediator;
using ISolutions.Project.Domain.Configurations;
using ISolutions.Project.Infrastructure.Database;
using ISolutions.Project.Infrastructure.Repositories;
using ISolutions.Project.Application.Features.User;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConfigurations(builder.Configuration);
builder.Services.AddProjectContexts(builder.Configuration);
builder.Services.AddMediator();
builder.Services.AddVersionConfiguration();
builder.Services.AddVersionSwaggerConfiguration();
builder.Services.AddMapperConfiguration();
builder.Services.AddRepositories();
builder.Services.AddUser();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options => app.DescribeApiVersions().ToList().ForEach(description =>
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant())));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
