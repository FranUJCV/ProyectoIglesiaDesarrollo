using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IglesiaDbContext _context;

        public CalendarController(IglesiaDbContext context)
        {
            _context = context;
        }

        // Método para cargar la vista principal del calendario
        public IActionResult Index()
        {
            return View();
        }

        // Método para obtener los eventos en formato JSON
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                description = e.Description,
                start = e.Start.ToString("yyyy-MM-dd"),
                end = e.End.ToString("yyyy-MM-dd")
            }).ToListAsync();

            return new JsonResult(events);
        }
    }
}
