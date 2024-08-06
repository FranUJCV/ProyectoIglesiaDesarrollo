namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Contribuciones
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public bool Eliminado { get; set; }
        public Guid MiembroId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid MetodoContribucionId { get; set; }
        public MetodoContribucion MetodoContribucion { get; set; }  
    }
}
