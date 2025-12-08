using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Controllers
{
    public class ConcesionarioAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
