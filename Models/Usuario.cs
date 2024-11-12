using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLottery.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Password { get; set; }
        public int Telefono { get; set; }
        public string Instagram { get; set; } = string.Empty;
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }= DateTime.Now;
    }
}
