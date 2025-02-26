using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechLottery.Models
{
    public class PagoDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; set; }
        [ForeignKey("PagoId")]
        public Pago Pago { get; set; }
        public int SorteoId { get; set; }
        [ForeignKey("SorteoId")]
        public Sorteo Sorteo { get; set; }
        public int Cantidad { get; set; } // Cantidad de boletos comprados
        public int Monto { get; set; } // Monto total para este sorteo
    
    }
}
