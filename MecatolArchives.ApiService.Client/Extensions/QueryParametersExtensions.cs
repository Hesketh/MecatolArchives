using MecatolArchives.Domain.Dto;
using System.Text;

namespace MecatolArchives.ApiService.Client.Extensions;

public static class QueryParametersExtensions
{
    extension(QueryParameters queryParameters)
    {
        public string ToQueryString()
        {
            var sb = new StringBuilder();

            sb.Append($"pageNumber={queryParameters.PageNumber}&pageSize={queryParameters.PageSize}&");

            if (sb.Length > 0)
            {
                // Remove the trailing '&'
                sb.Length--;
                return "?" + sb.ToString();
            }

            return string.Empty;
        }
    }
}
