namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class MetodoContribucion
    {
        public Guid Id { get; set; }
        public string Metodo { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Contribuciones> Contribucion { get; set; }
        public MetodoContribucion()
        {
            Contribucion = new HashSet<Contribuciones>();
        
        }
    }
}