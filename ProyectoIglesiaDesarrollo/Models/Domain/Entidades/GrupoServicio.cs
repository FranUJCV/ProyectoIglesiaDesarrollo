namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class GrupoServicio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid MiembroId { get; set; }
    }
}
