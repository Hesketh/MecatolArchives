using Hesketh.MecatolArchives.API.Auth;
using Hesketh.MecatolArchives.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(x =>
{
    // Could do with something more generic if this becomes an issue in the future
    // But this is because two Models used in the API have the same name
    // So this quick work around appends .Post to any models in the Post namespace
    if (x.FullName!.EndsWith($"Post.{x.Name}")) return $"Post.{x.Name}";
    if (x.FullName!.EndsWith($"Put.{x.Name}")) return $"Put.{x.Name}";
    return x.Name;
}));

builder.Services.Configure<AdminAccountOptions>(builder.Configuration.GetSection(AdminAccountOptions.SectionName));
builder.Services.AddTransient<IBasicAuthenticationService, BasicAuthenticationService>();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var databaseMode = builder.Configuration.GetValue<string>("DatabaseMode");
if (databaseMode == "memory")
{
    builder.Services.AddDbContext<MecatolArchivesDbContext>(options
        => options.UseInMemoryDatabase(nameof(MecatolArchivesDbContext)));
}
else if (databaseMode == "sqlite")
{
    builder.Services.AddDbContext<MecatolArchivesDbContext>(options
        => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else if (databaseMode == "mssql")
{
    builder.Services.AddDbContext<MecatolArchivesDbContext>(options
        => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration.GetValue("Https", false))
    app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MecatolArchivesDbContext>();
    if (db.Database.IsRelational() && !db.Database.IsInMemory())
    {
        await db.Database.MigrateAsync();
    }
}

app.Run();