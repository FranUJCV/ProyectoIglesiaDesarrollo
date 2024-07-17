using Microsoft.EntityFrameworkCore;

namespace ProyectoIglesiaDesarrollo.Models.Domain
{
    public class IglesiaDbContext: DbContext
    {
        public IglesiaDbContext(DbContextOptions<IglesiaDbContext> options) : base(options) { }
    }
}
