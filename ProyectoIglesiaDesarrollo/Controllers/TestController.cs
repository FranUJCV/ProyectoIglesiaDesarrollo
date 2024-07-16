using Microsoft.AspNetCore.Mvc;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
