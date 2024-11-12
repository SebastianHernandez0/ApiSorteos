using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLottery.Models
{
    public class Boleto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoletoId { get; set; }
        public int SorteoId { get; set; }
        [ForeignKey("SorteoId")]
        public Sorteo Sorteo { get; set; }
        public int UserId { get; set; }
        public string NumeroBoleto { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
