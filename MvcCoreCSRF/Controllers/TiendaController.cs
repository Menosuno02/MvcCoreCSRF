using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            // Comprobamos si existe el usuario para dejarle entrar o no
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Productos
            (string direccion, string[] producto)
        {
            // Comprobamos si usuario existe antes de realizar la compra
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            else
            {
                // Para enviar información entre acciones o controladores
                // se utiliza TempData
                TempData["DIRECCION"] = direccion;
                TempData["PRODUCTOS"] = producto;
                return RedirectToAction("PedidoFinal");
            }
        }

        public IActionResult PedidoFinal()
        {
            string[] productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"];
            return View(productos);
        }
    }
}
