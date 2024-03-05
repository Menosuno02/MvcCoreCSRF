using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login
            (string usuario, string password)
        {
            if (usuario.ToLower() == "admin"
                && password.ToLower() == "admin")
            {
                // Almacenamos en Session el usuario validado
                HttpContext.Session.SetString("USUARIO", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/password incorrectos";
                return View();
            }
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
