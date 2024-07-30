
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoIglesiaDesarrollo.Models
{
    public class Miembros
    {
        [Key]
        [Column(TypeName = "int")]
        public int MiembroId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nombres")]
        public String? Nombres { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Apellidos")]
        public String? Apellidos { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Nacimiento")]
        public DateTime FNacimiento { get; set; }

        //[Required]
        [Column(TypeName = "int")]
        [DisplayName("Edad")]
        public int Edad { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Genero")]
        public String? Genero { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Dirección")]
        public String? Direccion { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Rol")]
        public String? Rol { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Subir Imagen")]
        public IFormFile? ImageFile { get; set; }
        public object? Id { get; internal set; }
    }
}
