

namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Modulo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Metodo { get; set; }
        public string Controller { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }

        public Guid AgrupadoModulosId { get; set; }

        public AgrupadoModulos AgrupadoModulos { get; set; }

        public ICollection<ModulosRoles> ModulosRoles { get; set; }

        public Modulo()
        {
            ModulosRoles = new HashSet<ModulosRoles>();
        }
    }
}
