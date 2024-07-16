using Microsoft.AspNetCore.Mvc;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
