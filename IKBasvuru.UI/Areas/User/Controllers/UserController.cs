using Microsoft.AspNetCore.Mvc;

namespace IKBasvuru.UI.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
