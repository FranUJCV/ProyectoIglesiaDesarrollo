using Microsoft.EntityFrameworkCore;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;
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
        public DbSet<Miembros> Miembros { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<GrupoServicio> GrupoServicio { get; set; }
        public DbSet<Contribuciones> Contribuciones { get; set; }
        public DbSet<MetodoContribucion> MetodoContribucion { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgrupadoModulosConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new ModulosRolesConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new MiembrosConfig());
            modelBuilder.ApplyConfiguration(new GenerosConfig());
            modelBuilder.ApplyConfiguration(new GrupoServicioConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new ContribucionesConfig());
            modelBuilder.ApplyConfiguration(new MetodoContribucionConfig());
        }
    }
}

