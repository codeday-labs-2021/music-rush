using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace music_rush.Controllers
{
    public class MusicRushController : Controller
    {
        // 
        // GET: /MusicRush/
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

    }
}