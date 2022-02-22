using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class EpisodesController : Controller
    {
        [Route(template: "/episodi/episodio-1-divento-papa")]
        public IActionResult Episodio1()
            => View();

        [Route(template: "/episodi/episodio-2-prima-visita")]
        public IActionResult Episodio2()
            => View();

        [Route(template: "/episodi/episodio-3-iniziano-le-nausee")]
        public IActionResult Episodio3()
            => View();
    }
}
