using Hesketh.MecatolArchives.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(x =>
{
    // Could do with something more generic if this becomes an issue in the future
    // But this is because two Models used in the API have the same name
    // So this quick work around appends .Post to any models in the Post namespace
    if (x.FullName!.Contains("Post"))
    {
        return x.Name + ".Post";
    }
    return x.Name;
}));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<MecatolArchivesDbContext>(options
    => options.UseSqlite("Data Source=MecatolArchives.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MecatolArchivesDbContext>();
    await db.Database.MigrateAsync();
}

app.Run();
