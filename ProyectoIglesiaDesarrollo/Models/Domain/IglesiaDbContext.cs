﻿using Microsoft.EntityFrameworkCore;
using Project.Models;
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
        public DbSet<Miembros> Miembros { get; set; }
<<<<<<< HEAD
        
        
=======
        public DbSet<Generos> Generos { get; set; }
        public DbSet<GrupoServicio> GrupoServicio { get; set; }
>>>>>>> 8478d545d491c2edcdbc91c24420b334f0017316

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgrupadoModulosConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new ModulosRolesConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new MiembrosConfig());
<<<<<<< HEAD
            
=======
            modelBuilder.ApplyConfiguration(new GenerosConfig());
            modelBuilder.ApplyConfiguration(new GrupoServicioConfig());
>>>>>>> 8478d545d491c2edcdbc91c24420b334f0017316
        }
    }
}

