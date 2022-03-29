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

        [Route(template: "/episodi/episodio-4-dirlo-a-tutti")]
        public IActionResult Episodio4()
            => View();

        [Route(template: "/episodi/intermezzo-ninna-nanna-magica")]
        public IActionResult Intermezzo()
            => View();

        [Route(template: "/episodi/episodio-5-pensieri-sentieri")]
        public IActionResult Episodio5()
            => View();

        [Route(template: "/episodi/episodio-6-biscotto-della-paura")]
        public IActionResult Episodio6()
            => View();

        [Route(template: "/episodi/episodio-7-preparare-il-nido")]
        public IActionResult Episodio7()
            => View();

        [Route(template: "/episodi/episodio-8-coronavirus")]
        public IActionResult Episodio8()
            => View();
    }
}
