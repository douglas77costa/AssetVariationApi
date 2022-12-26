using AssetVariationApi.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssetVariationApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var message = context.Exception.Message;

                context.Result = new ObjectResult(new RequestResponse()
                {
                    Message = "Internal Server Error",
                    Info = message,
                    Source = context.Exception.Source
                })
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }
        }
    }
}