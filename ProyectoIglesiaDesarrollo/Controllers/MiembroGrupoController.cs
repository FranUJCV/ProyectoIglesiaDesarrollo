using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class MiembroGrupoController : Controller
    {
        private IglesiaDbContext _context;
        public MiembroGrupoController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var miembrogrupo = _context.MiembroGrupo.Where(w => w.Eliminado == false).ProjectToType<MiembroGrupoVm>().ToList();
            return View(miembrogrupo);

        }
        [HttpGet]
        public IActionResult Insertar()
        {
            var miembro = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembro.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });
            var gruposervicio = _context.GrupoServicio.Where(w => w.Eliminado == false).ProjectToType<GrupoServicioVm>().ToList();
            var itemsgrupo = gruposervicio.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });
            var nuevomiembrogrupo = new MiembroGrupoVm
            {
                Miembros = itemsmiembros,
                GrupoServicios = itemsgrupo,
            };
            return View(nuevomiembrogrupo);
        }
        [HttpPost]
        public IActionResult Insertar(MiembroGrupoVm vm)
        {
            var miembro = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembro.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });
            var gruposervicio = _context.GrupoServicio.Where(w => w.Eliminado == false).ProjectToType<GrupoServicioVm>().ToList();
            var itemsgrupo = gruposervicio.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            MiembroGrupo nuevomiembrogrupo = new MiembroGrupo();
            nuevomiembrogrupo.Eliminado = false;
            nuevomiembrogrupo.FechaCreacion = DateTime.Now;
            nuevomiembrogrupo.MiembroId = vm.MiembroId;
            nuevomiembrogrupo.GrupoServicioId = vm.GrupoServicioId;
            nuevomiembrogrupo.Id = Guid.NewGuid();
            _context.MiembroGrupo.Add(nuevomiembrogrupo);
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro de Grupo Agregado Correctamente";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid MiembroGrupoId)
        {
            var miembrogrupo = _context.MiembroGrupo.Where(w => w.Eliminado == false && w.Id == MiembroGrupoId).ProjectToType<MiembroGrupoVm>().FirstOrDefault();
            var miembro = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembro.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });
            var gruposervicio = _context.GrupoServicio.Where(w => w.Eliminado == false).ProjectToType<GrupoServicioVm>().ToList();
            var itemsgrupo = gruposervicio.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            miembrogrupo.Miembros = itemsmiembros;
            miembrogrupo.GrupoServicios = itemsgrupo;

            return View(miembrogrupo);
        }
        [HttpPost]
        public IActionResult Editar(MiembroGrupoVm vm)
        {
            var miembrogrupo = _context.MiembroGrupo.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            var miembro = _context.Miembros.Where(w => w.Eliminado == false).ProjectToType<MiembrosVm>().ToList();
            var itemsmiembros = miembro.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.MiembroId.ToString(),
                    Selected = false,
                };

            });
            var gruposervicio = _context.GrupoServicio.Where(w => w.Eliminado == false).ProjectToType<GrupoServicioVm>().ToList();
            var itemsgrupo = gruposervicio.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.Id.ToString(),
                    Selected = false,
                };

            });

            vm.Miembros = itemsmiembros;
            vm.GrupoServicios = itemsgrupo;
            miembrogrupo.MiembroId = vm.MiembroId;
            miembrogrupo.GrupoServicioId = vm.GrupoServicioId;
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro de Grupo Editado Correctamente";
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Eliminar(Guid MiembroGrupoId)
        {
            var miembrogruposervicio = _context.MiembroGrupo.Where(w => w.Eliminado == false && w.Id == MiembroGrupoId).ProjectToType<MiembroGrupoVm>().FirstOrDefault();

            return View(miembrogruposervicio);
        }
        [HttpPost]
        public IActionResult Eliminar(MiembroGrupoVm vm)
        {
            var miembrogruposervicio = _context.MiembroGrupo.Where(w => w.Eliminado == false && w.Id == vm.Id).FirstOrDefault();
            if (miembrogruposervicio == null)
            {
                TempData["mensaje"] = "No existe ese Miembro en Ese Grupo";
                return View(vm);
            }


            miembrogruposervicio.Eliminado = true;
            _context.SaveChanges();


            TempData["mensaje"] = "Miembro de Grupo Eliminado Correctamente";
            return RedirectToAction("Index");


        }
    }
}
