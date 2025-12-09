using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MecatolArchives.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDomainServices(IConfiguration configuration)
        {
            services.AddDbContext<MecatolArchivesDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MecatolArchives"),
                mssqlOptions =>
                {
                    mssqlOptions.MigrationsAssembly("MecatolArchives.DataAccess.Migrations.Mssql");
                });
            });

            services.AddScoped<IColourManagementService, ColourManagementService>();
            services.AddScoped<IPersonManagementService, PersonManagementService>();

            return services;
        }
    }
}
