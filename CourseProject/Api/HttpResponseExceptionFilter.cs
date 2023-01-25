using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Exceptions;

namespace Api
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                var value = httpResponseException.Value;

                context.Result = httpResponseException.StatusCode switch
                {
                    400 => new BadRequestObjectResult(value),
                    401 => new UnauthorizedObjectResult(value),
                    404 => new NotFoundObjectResult(value),
                    _ => new ObjectResult(value) { StatusCode = 500 }
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
