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
            if (queryParameters.Page != null)
            {
                sb.Append($"Page.Number={queryParameters.Page.Number}&Page.Size={queryParameters.Page.Size}&");
            }

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
