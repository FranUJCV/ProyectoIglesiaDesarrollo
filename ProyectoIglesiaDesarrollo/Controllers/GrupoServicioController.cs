using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class GrupoServicioController : Controller
    {
        private IglesiaDbContext _context;
        public GrupoServicioController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var gruposervicio = _context.GrupoServicio.Where(w => w.Eliminado == false).ProjectToType<GrupoServicioVm>().ToList();
            return View(gruposervicio);

        }
        [HttpGet]
        public IActionResult Insertar()
        {
            var miembros = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembros.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });
            var nuevogrupo = new GrupoServicioVm
            {
                Miembros = itemsmiembros,
            };
            return View(nuevogrupo);
        }
        [HttpPost]
        public IActionResult Insertar(GrupoServicioVm vm)
        {
            var miembros = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembros.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });

            GrupoServicio nuevogrupo = new GrupoServicio();
            nuevogrupo.Nombre = vm.Nombre;
            nuevogrupo.Descripcion = vm.Descripcion;
            nuevogrupo.Eliminado = false;
            nuevogrupo.FechaCreacion = DateTime.Now;
            nuevogrupo.MiembroId = vm.MiembroId;
            nuevogrupo.Id = Guid.NewGuid();
            _context.GrupoServicio.Add(nuevogrupo);
            _context.SaveChanges();


            TempData["mensaje"] = "Grupo Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid GrupoServicioId)
        {
            var grupo = _context.GrupoServicio.Where(w => w.Eliminado == false && w.Id == GrupoServicioId).ProjectToType<GrupoServicioVm>().FirstOrDefault();
            var miembros = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembros.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });

            grupo.Miembros = itemsmiembros;

            return View(grupo);
        }
        [HttpPost]
        public IActionResult Editar(GrupoServicioVm vm)
        {
            var grupo = _context.GrupoServicio.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            var miembros = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembros.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });

            vm.Miembros = itemsmiembros;
            grupo.Nombre = vm.Nombre;
            grupo.Descripcion = vm.Descripcion;
            grupo.MiembroId = vm.MiembroId;
            _context.SaveChanges();


            TempData["mensaje"] = "Grupo Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid GrupoServicioId)
        {
            var grupo = _context.GrupoServicio.Where(w => w.Eliminado == false && w.Id == GrupoServicioId).ProjectToType<GrupoServicioVm>().FirstOrDefault();

            return View(grupo);
        }
        [HttpPost]
        public IActionResult Eliminar(GrupoServicioVm vm)
        {
            var grupo = _context.GrupoServicio.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (grupo == null)
            {
                TempData["mensaje"] = "No existe ese Grupo";
                return View(vm);
            }


            grupo.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Grupo Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
