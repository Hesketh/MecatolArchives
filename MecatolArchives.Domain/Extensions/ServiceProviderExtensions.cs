using MecatolArchives.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MecatolArchives.Domain.Extensions;

public static class ServiceProviderExtensions
{
    extension (IServiceProvider serviceProvider)
    {
        public void MigrateDomainDatabases()
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MecatolArchivesDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
