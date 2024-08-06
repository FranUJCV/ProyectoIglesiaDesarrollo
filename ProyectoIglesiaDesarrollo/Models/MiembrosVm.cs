using Microsoft.AspNetCore.Mvc.Rendering;


namespace ProyectoIglesiaDesarrollo.Models
{
    public class MiembrosVm
    {
        public Guid MiembroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public RolVm Rol { get; set; }
        public Guid RolId { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public GenerosVm Generos { get; set; }
        public Guid GeneroId { get; set; }
        public List<SelectListItem> Genero { get; set; }


    }
}
