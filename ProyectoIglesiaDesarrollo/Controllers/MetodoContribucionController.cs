using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class MetodoContribucionController : Controller
    {
        private IglesiaDbContext _context;
        public MetodoContribucionController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false).ProjectToType<MetodoContribucionVm>().ToList();
            return View(metodo);

        }
        [HttpGet]
        public IActionResult Insertar()
        {
            
            var nuevometodo = new MetodoContribucionVm
            {
            };
            return View(nuevometodo);
        }
        [HttpPost]
        public IActionResult Insertar(MetodoContribucionVm vm)
        {
            
            MetodoContribucion nuevometodo = new MetodoContribucion();
            nuevometodo.Metodo = vm.Metodo;
            nuevometodo.Eliminado = false;
            nuevometodo.FechaCreacion = DateTime.Now;
            nuevometodo.Id = Guid.NewGuid();
            _context.MetodoContribucion.Add(nuevometodo);
            _context.SaveChanges();


            TempData["mensaje"] = "Metodo Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid MetodoContribucionId)
        {
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false && w.Id == MetodoContribucionId).ProjectToType<MetodoContribucionVm>().FirstOrDefault();

            return View(metodo);
        }
        [HttpPost]
        public IActionResult Editar(MetodoContribucionVm vm)
        {
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            

            metodo.Metodo = vm.Metodo;
            _context.SaveChanges();


            TempData["mensaje"] = "Metodo Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid MetodoContribucionId)
        {
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false && w.Id == MetodoContribucionId).ProjectToType<MetodoContribucionVm>().FirstOrDefault();

            return View(metodo);
        }
        [HttpPost]
        public IActionResult Eliminar(MetodoContribucionVm vm)
        {
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (metodo == null)
            {
                TempData["mensaje"] = "No existe ese Metodo";
                return View(vm);
            }


            metodo.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Metodo Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
