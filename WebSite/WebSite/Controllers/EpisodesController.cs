using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class EpisodesController : Controller
    {
        [Route(template: "/episodi/episodio-1-divento-papa")]
        public IActionResult Episodio1()
            => View();
    }
}
