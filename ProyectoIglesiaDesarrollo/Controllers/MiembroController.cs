using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using System.Diagnostics.Metrics;


namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class MiembroController : Controller
    {
        private readonly IglesiaDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MiembroController(IglesiaDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miembros.ToListAsync());
        }

        // GET: Miembros/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembros = await _context.Miembros
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembros == null)
            {
                return NotFound();
            }

            return View(miembros);
        }

        // GET: Miembross/Agregar
        public IActionResult AddOrEdit(int Id = 0)
        {
            if (Id == 0)
                return View(new Miembros());
            else
                return View(_context.Miembros.Find(Id));
        }

        // POST: Miembros/Agregar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("MiembroId,Nombres,Apellidos,Fecha de Nacimiento,Edad,Genero,Direccion,Rol,ImageFile")] Miembros miembros)
        {
            if (ModelState.IsValid)
            {
                if (miembros.MiembroId == 0)
                {

                    //guardar imagen en wwwroot/image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(miembros.ImageFile.FileName);
                    string extension = Path.GetExtension(miembros.ImageFile.FileName);
                    miembros.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await miembros.ImageFile.CopyToAsync(fileStream);
                    }
                    _context.Add(miembros);
                }
                else
                {
                    _context.Update(miembros);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miembros);
        }
        // GET: Miembross/Editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembros = await _context.Miembros.FindAsync(id);
            if (miembros == null)
            {
                return NotFound();
            }
            return View(miembros);
        }

        // POST: Miembros/Editar

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiembroId,Nombres,Apellidos,Fecha de Nacimiento,Edad,Genero,Direccion,Rol,ImageFile")] Miembros miembros)
        {
            if (id != miembros.MiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembros.MiembroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(miembros);
        }

        // GET: Miembros/Eliminar
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembros = await _context.Miembros
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembros == null)
            {
                return NotFound();
            }

            return View(miembros);
        }

        // POST: Miembros/Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembros = await _context.Miembros.FindAsync(id);
            _context.Miembros.Remove(miembros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroExists(int id)
        {
            return _context.Miembros.Any(e => e.MiembroId == id);
        }
    }
}