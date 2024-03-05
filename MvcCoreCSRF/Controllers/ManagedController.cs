using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
