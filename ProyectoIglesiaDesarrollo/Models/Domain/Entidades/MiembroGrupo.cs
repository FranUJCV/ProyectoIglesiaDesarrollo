namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class MiembroGrupo
    {
        public Guid Id { get; set; }
        public Guid MiembroId { get; set; }
        public Miembros Miembro { get; set; }
        public Guid GrupoServicioId { get; set; }
        public GrupoServicio GrupoServicio { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
