

namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class Miembros
    {
        public Guid MiembroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }       
        public int Edad { get; set; }
        public Guid GeneroId { get; set; }
        public Generos Generos { get; set; }       
        public string Direccion { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
