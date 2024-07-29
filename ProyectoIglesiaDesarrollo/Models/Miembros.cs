
using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIglesiaDesarrollo.Models
{
    public class Miembros
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string DNI { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
