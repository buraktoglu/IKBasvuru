using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
