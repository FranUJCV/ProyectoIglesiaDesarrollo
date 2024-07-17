using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProyectoIglesiaDesarrollo.Models.Domain
{
    public class ConfiguracionEntidades
    {
        public class AgrupadoModulosConfig : IEntityTypeConfiguration<AgrupadoModulos>
        {
            public void Configure(EntityTypeBuilder<AgrupadoModulos> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasKey(x => x.Modulos).WithOne(a => a.AgrupadoModulos).HasForeignKey(x => x.AgrupadoModulos);
            }
        }
        public class ModuloConfig : IEntityTypeConfiguration<Modulo>
        {
            public void Configure(EntityTypeBuilder<Modulo> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasKey(x => x.ModulosRoles).WithOne(a => a.Modulo).HasForeignKey(x => x.ModuloId);
            }
        }
        public class RolConfig : IEntityTypeConfiguration<Rol>
        {
            public void Configure(EntityTypeBuilder<Rol> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasKey(x => x.ModulosRoles).WithOne(a => a.Rol).HasForeignKey(x => x.RolId);
                builder.HasKey(x => x.Usuarios).WithOne(a => a.Rol).HasForeignKey(x => x.RolId);
            }
        }
        public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                builder.HasKey(x => x.Id);             
            }
        }
    }
}
