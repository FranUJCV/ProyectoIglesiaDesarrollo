using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class ContribucionesController : Controller
    {
        private IglesiaDbContext _context;
        public ContribucionesController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contribucion = _context.Contribuciones.Where(w => w.Eliminado == false).ProjectToType<ContribucionesVm>().ToList();
            return View(contribucion);

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
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false).ProjectToType<MetodoContribucionVm>().ToList();
            var itemsmetodo = metodo.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Metodo,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var nuevacontribucion = new ContribucionesVm
            {
                Miembros = itemsmiembros,
                MetodoContribuciones = itemsmetodo,
            };
            return View(nuevacontribucion);
        }
        [HttpPost]
        public IActionResult Insertar(ContribucionesVm vm)
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
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false).ProjectToType<MetodoContribucionVm>().ToList();
            var itemsmetodo = metodo.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Metodo,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            Contribuciones nuevacontribucion = new Contribuciones();
            nuevacontribucion.Cantidad = vm.Cantidad;
            nuevacontribucion.Eliminado = false;
            nuevacontribucion.FechaCreacion = DateTime.Now;
            nuevacontribucion.MiembroId = vm.MiembroId;
            nuevacontribucion.MetodoContribucionId = vm.MetodoContribucionId;
            nuevacontribucion.Id = Guid.NewGuid();
            _context.Contribuciones.Add(nuevacontribucion);
            _context.SaveChanges();


            TempData["mensaje"] = "Contribucion Agregada Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid ContribucionesId)
        {
            var contribuciones = _context.Contribuciones.Where(w => w.Eliminado == false && w.Id == ContribucionesId).ProjectToType<ContribucionesVm>().FirstOrDefault();
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
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false).ProjectToType<MetodoContribucionVm>().ToList();
            var itemsmetodo = metodo.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Metodo,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            contribuciones.Miembros = itemsmiembros;
            contribuciones.MetodoContribuciones = itemsmetodo;

            return View(contribuciones);
        }
        [HttpPost]
        public IActionResult Editar(ContribucionesVm vm)
        {
            var contribuciones = _context.Contribuciones.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
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
            var metodo = _context.MetodoContribucion.Where(w => w.Eliminado == false).ProjectToType<MetodoContribucionVm>().ToList();
            var itemsmetodo = metodo.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Metodo,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            vm.Miembros = itemsmiembros;
            vm.MetodoContribuciones = itemsmetodo;
            contribuciones.Cantidad = vm.Cantidad;
            contribuciones.MiembroId = vm.MiembroId;
            contribuciones.MetodoContribucionId = vm.MetodoContribucionId;
            _context.SaveChanges();


            TempData["mensaje"] = "Contribucion Editada Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid ContribucionesId)
        {
            var contribuciones = _context.Contribuciones.Where(w => w.Eliminado == false && w.Id == ContribucionesId).ProjectToType<ContribucionesVm>().FirstOrDefault();

            return View(contribuciones);
        }
        [HttpPost]
        public IActionResult Eliminar(ContribucionesVm vm)
        {
            var contribuciones = _context.Contribuciones.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (contribuciones == null)
            {
                TempData["mensaje"] = "No existe esa Contribucion";
                return View(vm);
            }


            contribuciones.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Contribucion Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
