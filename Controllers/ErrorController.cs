using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace newmvccore.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController(ILogger<ErrorController> logger)
        {
            Logger = logger;
        }

        public ILogger<ErrorController> Logger { get; }

        [Route("Error/{statuscode}")]
        public IActionResult Error(int statuscode)
        {
            var code = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    ViewBag.error= "Requested page not found";
                    ViewBag.path = code.OriginalPath;
                    ViewBag.qs = code.OriginalQueryString;
                    //Logger.LogWarning($"the reuested url not found {code.OriginalPath}");
                    break;                
            }
            return View();
        }

        [Route("Error/Exception")]
        public IActionResult Exception()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = ex.Path;
            ViewBag.error = ex.Error.Message;
            ViewBag.stacktrace = ex.Error.StackTrace;
            ViewBag.innerexception = ex.Error.InnerException;

            //Logger.LogError($"the exception is {ex.Path} {ex.Error.Message} {ex.Error.StackTrace} {ex.Error.InnerException}");
            return View();
        }
    }
}
