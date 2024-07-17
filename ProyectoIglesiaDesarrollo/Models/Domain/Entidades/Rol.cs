

namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<ModulosRoles> ModulosRoles { get; set; }
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
            ModulosRoles = new HashSet<ModulosRoles>();
        }
    }
}
