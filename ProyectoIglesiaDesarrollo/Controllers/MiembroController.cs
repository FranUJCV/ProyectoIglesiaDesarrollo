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

        public MiembroController(IglesiaDbContext context)
        {
            _context = context;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miembros.ToListAsync());
        }

        // GET: Miembross/Agregar
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miembros/Agregar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,PhoneNumber,Address,BirthDate,DNI,Role")] Miembros Miembros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Miembros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Miembros);
        }
    }
}