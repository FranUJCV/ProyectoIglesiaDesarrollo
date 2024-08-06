using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using System.Collections.Generic;
using System.Drawing;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                description = e.Description,
                allDay = e.AllDay,
                color = e.Color,
                start = e.Start.ToString("yyyy-MM-ddTHH:mm:ss"),
                end = e.End.ToString("yyyy-MM-ddTHH:mm:ss")
            }).ToListAsync();

            return new JsonResult(events);
        }
    }
}
