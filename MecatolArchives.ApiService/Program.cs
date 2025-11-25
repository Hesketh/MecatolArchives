using MecatolArchives.ApiService.Filters;
using MecatolArchives.Domain.Extensions;
using MecatolArchives.ServiceDefaults;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi("mecatol_archives");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotFoundExceptionFilter>();
});

builder.Services.AddDomainServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.Services.MigrateDomainDatabases();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/openapi/mecatol_archives.json", "Mecatol Archives API");
        x.DocumentTitle = "Mecatol Archives API Documentation";
    });
}

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();