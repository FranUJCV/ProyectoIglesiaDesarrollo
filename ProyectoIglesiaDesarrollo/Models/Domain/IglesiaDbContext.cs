using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;
using System.Diagnostics.Metrics;
using static ProyectoIglesiaDesarrollo.Models.Domain.ConfiguracionEntidades;

namespace ProyectoIglesiaDesarrollo.Models.Domain
{
    public class IglesiaDbContext : DbContext
    {
        public IglesiaDbContext(DbContextOptions<IglesiaDbContext> options) : base(options) { }

        public DbSet<AgrupadoModulos> AgrupadoModulos { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<ModulosRoles> ModulosRoles { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgrupadoModulosConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new ModulosRolesConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            
        }
    }
}

