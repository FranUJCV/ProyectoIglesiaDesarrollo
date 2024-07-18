namespace ProyectoIglesiaDesarrollo.Models
{
    public class UsuarioVm
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RolVm Rol {  get; set; }
        public List<AgrupadoVm> Menu { get; set; }
    }
}
