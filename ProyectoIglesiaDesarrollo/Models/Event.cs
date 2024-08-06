namespace ProyectoIglesiaDesarrollo.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Boolean AllDay { get; set; }
        public string Color { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
    }
}
