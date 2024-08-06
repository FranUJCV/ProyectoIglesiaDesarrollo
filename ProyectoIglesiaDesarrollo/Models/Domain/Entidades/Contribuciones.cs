namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Contribuciones
    {
        public Guid Id { get; set; }
        public string Genero { get; set; }
        public bool Eliminado { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
