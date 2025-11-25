using MecatolArchives.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MecatolArchives.ApiService.Filters
{
    public class NotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EntityNotFoundException ex)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.NotFoundObjectResult(new
                {
                    Message = ex.Message,
                    ExceptionType = ex.GetType().Name
                });
            }
        }
    }
}
