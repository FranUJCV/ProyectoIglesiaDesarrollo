using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class MiembroGrupoVm
    {
        public Guid Id { get; set; }
        public MiembrosVm Miembro { set; get; }
        public Guid MiembroId { set; get; }
        public List<SelectListItem> Miembros { set; get; }
        public GrupoServicioVm GrupoServicio { get; set; }
        public Guid GrupoServicioId { get; set; }
        public List<SelectListItem> GrupoServicios { get; set; }
    }
}
