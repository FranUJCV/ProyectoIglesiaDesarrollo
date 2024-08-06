using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class GrupoServicioVm
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public MiembrosVm Miembro { set; get; }
        public Guid MiembroId { set; get; }
        public List<SelectListItem> Miembros { set; get; }
    }
}
