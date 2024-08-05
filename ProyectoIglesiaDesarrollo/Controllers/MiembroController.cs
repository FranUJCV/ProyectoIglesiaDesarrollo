using Mapster;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;
using System.Diagnostics.Metrics;


namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class MiembroController : Controller
    {
        private IglesiaDbContext _context;
        public MiembroController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var miembros = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            return View(miembros);

        }
        [HttpGet]
        public IActionResult Insertar()
        {
            var roles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            var itemsroles = roles.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var generos = _context.Generos.Where(w => w.Eliminado == false).ProjectToType<GenerosVm>().ToList();
            var itemsgeneros = generos.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Genero,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var nuevomiembro = new MiembrosVm
            {
                Roles = itemsroles,
                Genero = itemsgeneros,
            };
            return View(nuevomiembro);
        }
        [HttpPost]
        public IActionResult Insertar(MiembrosVm vm)
        {
            var roles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            var itemsroles = roles.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var generos = _context.Generos.Where(w => w.Eliminado == false).ProjectToType<GenerosVm>().ToList();
            var itemsgeneros = generos.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Genero,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            Miembros nuevomiembro = new Miembros();
            nuevomiembro.Nombre = vm.Nombre;
            nuevomiembro.Apellido = vm.Apellido;
            nuevomiembro.Edad = vm.Edad;
            nuevomiembro.Direccion = vm.Direccion;
            nuevomiembro.Eliminado = false;
            nuevomiembro.FechaCreacion = DateTime.Now;
            nuevomiembro.GeneroId = vm.GeneroId;
            nuevomiembro.RolId = vm.RolId;
            nuevomiembro.MiembroId = Guid.NewGuid();
            _context.Miembros.Add(nuevomiembro);
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid MiembrosId)
        {
            var miembro = _context.Miembros.Where(w => w.Eliminado == false && w.MiembroId == MiembrosId).ProjectToType<MiembrosVm>().FirstOrDefault();
            var roles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            var itemsroles = roles.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var generos = _context.Generos.Where(w => w.Eliminado == false).ProjectToType<GenerosVm>().ToList();
            var itemsgeneros = generos.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Genero,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });


            miembro.Roles = itemsroles;
            miembro.Genero = itemsgeneros;
           

            return View(miembro);
        }
        [HttpPost]
        public IActionResult Editar(MiembrosVm vm)
        {
            var miembros = _context.Miembros.Where(w => w.Eliminado == false && w.MiembroId == vm.MiembroId).FirstOrDefault();
            var roles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            var itemsroles = roles.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Descripcion,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var generos = _context.Generos.Where(w => w.Eliminado == false).ProjectToType<GenerosVm>().ToList();
            var itemsgeneros = generos.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Genero,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            vm.Roles = itemsroles;
            vm.Genero = itemsgeneros;
            miembros.Nombre = vm.Nombre;
            miembros.Apellido = vm.Apellido;
            miembros.Edad = vm.Edad;
            miembros.Direccion = vm.Direccion;
            miembros.GeneroId = vm.GeneroId;
            miembros.RolId = vm.RolId;
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid MiembrosId)
        {
            var miembro = _context.Miembros.Where(w => w.Eliminado == false && w.MiembroId == MiembrosId).ProjectToType<MiembrosVm>().FirstOrDefault();

            return View(miembro);
        }
        [HttpPost]
        public IActionResult Eliminar(MiembrosVm vm)
        {
            var miembro = _context.Miembros.Where(w => w.Eliminado == false && w.MiembroId == vm.MiembroId).FirstOrDefault();
            if (miembro == null)
            {
                TempData["mensaje"] = "No existe ese Miembro";
                return View(vm);
            }


            miembro.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}