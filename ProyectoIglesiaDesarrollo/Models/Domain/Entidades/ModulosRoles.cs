

namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class ModulosRoles
    {
        public Guid Id { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }
        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
        public Modulo Modulo { get; set; }
        public Guid ModuloId { get; set; }
    }
}
