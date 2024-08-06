using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class GeneroController : Controller
    {
        private IglesiaDbContext _context;
        public GeneroController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var roles = _context.Generos.Where(w => w.Eliminado == false).ProjectToType<GenerosVm>().ToList();
            return View(roles);

        }
        [HttpGet]
        public IActionResult Insertar()
        {
            var usuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            var itemsusuarios = usuarios.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var nuevogenero = new GenerosVm
            {
                Usuarios = itemsusuarios,
            };
            return View(nuevogenero);
        }
        [HttpPost]
        public IActionResult Insertar(GenerosVm vm)
        {
            var usuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            var itemsusuarios = usuarios.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            Generos nuevogenero = new Generos();
            nuevogenero.Genero = vm.Genero;
            nuevogenero.Eliminado = false;
            nuevogenero.FechaCreacion = DateTime.Now;
            nuevogenero.UsuarioId = vm.UsuarioId;
            nuevogenero.Id = Guid.NewGuid();
            _context.Generos.Add(nuevogenero);
            _context.SaveChanges();


            TempData["mensaje"] = "Genero Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid GeneroId)
        {
            var genero = _context.Generos.Where(w => w.Eliminado == false && w.Id == GeneroId).ProjectToType<GenerosVm>().FirstOrDefault();
            var usuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            var itemsusuarios = usuarios.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            genero.Usuarios = itemsusuarios;

            return View(genero);
        }
        [HttpPost]
        public IActionResult Editar(GenerosVm vm)
        {
            var genero = _context.Generos.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            var usuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            var itemsusuarios = usuarios.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            vm.Usuarios = itemsusuarios;
            genero.Genero = vm.Genero;
            genero.UsuarioId = vm.UsuarioId;
            _context.SaveChanges();


            TempData["mensaje"] = "Rol Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid GeneroId)
        {
            var genero = _context.Generos.Where(w => w.Eliminado == false && w.Id == GeneroId).ProjectToType<GenerosVm>().FirstOrDefault();

            return View(genero);
        }
        [HttpPost]
        public IActionResult Eliminar(GenerosVm vm)
        {
            var genero = _context.Generos.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (genero == null)
            {
                TempData["mensaje"] = "No existe ese Genero";
                return View(vm);
            }


            genero.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Genero Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
