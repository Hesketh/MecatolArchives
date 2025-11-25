using MecatolArchives.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace MecatolArchives.Domain.Extensions;

internal static class DbSetExtensions
{
    extension<T>(DbSet<T> queryable) where T : class
    {
        public IQueryable<T> Query(QueryParameters query)
        {
            return queryable
                .AsNoTracking()
                .Skip((query.Page.Number - 1) * query.Page.Size)
                .Take(query.Page.Size);
        }
    }
}
