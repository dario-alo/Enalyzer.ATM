using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Enalyzer.ATM.Web.Controllers
{
    [AllowAnonymous]
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("401")]
        public IActionResult NotAuthorized()
        {
            return View("Error", 401);
        }

        [Route("403")]
        public IActionResult Forbidden()
        {
            return View("Error", 403);
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View("Error", 404);
        }

        [Route("500")]
        public IActionResult InternalServerError()
        {
            return View("Error", 500);
        }

        [Route("503")]
        public IActionResult ServiceUnavailable()
        {
            return View("Error", 503);
        }
    }
}