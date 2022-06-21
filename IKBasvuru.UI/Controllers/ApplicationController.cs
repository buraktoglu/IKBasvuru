using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
