using MecatolArchives.ApiService.Filters;
using MecatolArchives.Domain.Extensions;
using MecatolArchives.ServiceDefaults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotFoundExceptionFilter>();
});

builder.Services.AddDomainServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.Services.MigrateDomainDatabases();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference("api", options =>
    {
        options.Title = "Mecatol Archives API";
        options.Telemetry = false;
        options.ShowDeveloperTools = DeveloperToolsVisibility.Never;
    });
}

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();