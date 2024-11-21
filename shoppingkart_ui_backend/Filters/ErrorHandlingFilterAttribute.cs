using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace shoppingkart_ui_backend.Filters
{
    public class ErrorHandlingFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            //var problemDetails = new ProblemDetails
            //{

            //};
            var errorResult = new { error = "error handled from the filter while processing the exception" };
            context.Result = new ObjectResult(errorResult) { StatusCode = 500 };
            context.ExceptionHandled = true;
        }
    }
} 