using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace shoppingkart_ui_backend.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Index()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
            return Problem();
        }
    }
}
