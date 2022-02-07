using Microsoft.AspNetCore.Mvc;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        [Route(template: "/")]
        public IActionResult Index()
            => View();

        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}