using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
