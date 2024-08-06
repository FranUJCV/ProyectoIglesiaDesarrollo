namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Generos
    {
        public Guid Id { get; set; }
        public string Genero { get; set; }
        public bool Eliminado { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Miembros> Miembro { get; set; }
        public Generos()
        {
            Miembro = new HashSet<Miembros>();
        
        }
    }
}
