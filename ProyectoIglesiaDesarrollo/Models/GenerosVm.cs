using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class GenerosVm
    {
        public Guid Id { get; set; }
        public string Genero { get; set; }
        public UsuarioVm Usuario { set; get; }
        public Guid UsuarioId { set; get; }
        public List<SelectListItem> Usuarios { set; get; }
    }
}
