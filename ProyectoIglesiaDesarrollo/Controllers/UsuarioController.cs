using Microsoft.AspNetCore.Mvc;
using ProyectoIglesiaDesarrollo.Models.Domain;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class UsuarioController : Controller
    {
        private IglesiaDbContext _context;
        public UsuarioController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}