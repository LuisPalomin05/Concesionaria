using Microsoft.AspNetCore.Mvc;

namespace ConcesionariaAPI.Controllers
{
    public class ConcesionariaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
