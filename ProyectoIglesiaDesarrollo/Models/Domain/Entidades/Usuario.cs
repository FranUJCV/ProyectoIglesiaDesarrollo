namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
