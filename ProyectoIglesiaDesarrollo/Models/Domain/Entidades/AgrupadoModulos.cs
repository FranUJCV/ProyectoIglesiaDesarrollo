namespace ProyectoIglesiaDesarrollo.Models.Domain.Entidades
{
    public class AgrupadoModulos
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }
        public ICollection<Modulo> Modulos { get; set; }
        public AgrupadoModulos()
        {
            Modulos = new HashSet<Modulo>();
        }
    }
}
