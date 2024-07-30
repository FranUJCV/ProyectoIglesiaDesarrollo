using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class RolController : Controller
    {
        private IglesiaDbContext _context;
        public RolController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var roles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
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
            var nuevorol = new RolVm
            {
                Usuarios = itemsusuarios,
            };
            return View(nuevorol);
        }
        [HttpPost]
        public IActionResult Insertar(RolVm vm)
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

            Rol nuevorol = new Rol();
            nuevorol.Descripcion = vm.Descripcion;
            nuevorol.Eliminado = false;
            nuevorol.FechaCreacion = DateTime.Now;
            nuevorol.UsuarioId = vm.UsuarioId;
            nuevorol.Id = Guid.NewGuid();
            _context.Rol.Add(nuevorol);
            _context.SaveChanges();


            TempData["mensaje"] = "Rol Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid RolId)
        {
            var rol = _context.Rol.Where(w => w.Eliminado == false && w.Id == RolId).ProjectToType<RolVm>().FirstOrDefault();
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

            rol.Usuarios = itemsusuarios;

            return View(rol);
        }
        [HttpPost]
        public IActionResult Editar(RolVm vm)
        {
            var rol = _context.Rol.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
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
            rol.Descripcion = vm.Descripcion;
            rol.UsuarioId = vm.UsuarioId;
            _context.SaveChanges();


            TempData["mensaje"] = "Rol Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid RolId)
        {
            var rol = _context.Rol.Where(w => w.Eliminado == false && w.Id == RolId).ProjectToType<RolVm>().FirstOrDefault();

            return View(rol);
        }
        [HttpPost]
        public IActionResult Eliminar(RolVm vm)
        {
            var rol = _context.Rol.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (rol == null)
            {
                TempData["mensaje"] = "No existe ese Rol";
                return View(vm);
            }


            rol.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Rol Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
