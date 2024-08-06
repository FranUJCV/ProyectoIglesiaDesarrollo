using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class ContribucionesVm
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public MiembrosVm Miembro { set; get; }
        public Guid MiembroId { set; get; }
        public List<SelectListItem> Miembros { set; get; }
        public MetodoContribucionVm MetodoContribucion { get; set; }
        public Guid MetodoContribucionId { get; set; }
        public List<SelectListItem> MetodoContribuciones { get; set; }
    }
}