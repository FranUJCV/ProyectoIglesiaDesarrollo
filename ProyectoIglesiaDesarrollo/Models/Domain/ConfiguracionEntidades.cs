using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;

namespace ProyectoIglesiaDesarrollo.Models.Domain
{
    public class ConfiguracionEntidades
    {
        public class AgrupadoModulosConfig : IEntityTypeConfiguration<AgrupadoModulos>
        {
            public void Configure(EntityTypeBuilder<AgrupadoModulos> builder)
            {
                builder.HasKey(am => am.Id);

                builder.Property(am => am.Descripcion)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(am => am.Eliminado)
                       .IsRequired();

                builder.Property(am => am.FechaCreacion)
                       .IsRequired();

                builder.Property(am => am.UsuarioId)
                       .IsRequired();

                builder.HasMany(am => am.Modulos)
                       .WithOne(m => m.AgrupadoModulos)
                       .HasForeignKey(m => m.AgrupadoModulosId);
            }
        }
        public class ModuloConfig : IEntityTypeConfiguration<Modulo>
        {
            public void Configure(EntityTypeBuilder<Modulo> builder)
            {
                builder.HasKey(m => m.Id);

                builder.Property(m => m.Nombre)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Metodo)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Controller)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();

                builder.Property(m => m.UsuarioId)
                       .IsRequired();

                builder.Property(m => m.AgrupadoModulosId)
                       .IsRequired();

                builder.HasOne(m => m.AgrupadoModulos)
                       .WithMany(am => am.Modulos)
                       .HasForeignKey(m => m.AgrupadoModulosId);
            }
        }
        public class RolConfig : IEntityTypeConfiguration<Rol>
        {
            public void Configure(EntityTypeBuilder<Rol> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasMany(x => x.ModulosRoles).WithOne(a => a.Rol).HasForeignKey(x => x.RolId);
                builder.HasMany(x => x.Usuarios).WithOne(a => a.Rol).HasForeignKey(x => x.RolId);
                builder.HasMany(x => x.Miembro).WithOne(a => a.Rol).HasForeignKey(x => x.RolId);
            }
        }
        public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                builder.HasKey(x => x.Id);             
            }
        }
        public class ModulosRolesConfig : IEntityTypeConfiguration<ModulosRoles>
        {
            public void Configure(EntityTypeBuilder<ModulosRoles> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
        public class MiembrosConfig : IEntityTypeConfiguration<Miembros>
        {
            public void Configure(EntityTypeBuilder<Miembros> builder)
            {
                builder.HasKey(x => x.MiembroId);

                builder.Property(m => m.Nombre)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Apellido)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();

                builder.Property(m => m.Edad).HasColumnType("int").HasColumnName("Edad")
                       .IsRequired();
                builder.HasMany(x => x.Contribucion).WithOne(a => a.Miembro).HasForeignKey(x => x.MiembroId);
                builder.HasMany(x => x.MiembroGrupo).WithOne(a => a.Miembro).HasForeignKey(x => x.MiembroId);
            }
        }
        public class GenerosConfig : IEntityTypeConfiguration<Generos>
        {
            public void Configure(EntityTypeBuilder<Generos> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(m => m.Genero)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();
                builder.HasMany(x => x.Miembro).WithOne(a => a.Generos).HasForeignKey(x => x.GeneroId);
            }
        }
        public class GrupoServicioConfig : IEntityTypeConfiguration<GrupoServicio>
        {
            public void Configure(EntityTypeBuilder<GrupoServicio> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(m => m.Nombre)
                       .IsRequired()
                       .HasMaxLength(200);
                builder.Property(m => m.Descripcion)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();
                builder.HasMany(x => x.MiembroGrupo).WithOne(a => a.GrupoServicio).HasForeignKey(x => x.GrupoServicioId);

            }
        }

        public class EventConfig : IEntityTypeConfiguration<Event>
        {
            public void Configure(EntityTypeBuilder<Event> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
        public class ContribucionesConfig : IEntityTypeConfiguration<Contribuciones>
        {
            public void Configure(EntityTypeBuilder<Contribuciones> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(m => m.Cantidad).HasColumnType("int").HasColumnName("Cantidad")
                       .IsRequired();
                
                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();
            }
        }
        public class MetodoContribucionConfig : IEntityTypeConfiguration<MetodoContribucion>
        {
            public void Configure(EntityTypeBuilder<MetodoContribucion> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(m => m.Metodo)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();
                builder.HasMany(x => x.Contribucion).WithOne(a => a.MetodoContribucion).HasForeignKey(x => x.MetodoContribucionId);
            }
        }
        public class MiembroGrupoConfig : IEntityTypeConfiguration<MiembroGrupo>
        {
            public void Configure(EntityTypeBuilder<MiembroGrupo> builder)
            {
                builder.HasKey(x => x.Id);             

                builder.Property(m => m.Eliminado)
                       .IsRequired();

                builder.Property(m => m.FechaCreacion)
                       .IsRequired();
            }
        }
    }
}
