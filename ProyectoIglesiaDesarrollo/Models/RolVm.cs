using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class RolVm
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public UsuarioVm Usuario { set; get; }
        public Guid UsuarioId { set; get; }
        public List<SelectListItem> Usuarios { set; get; }

    }
}
