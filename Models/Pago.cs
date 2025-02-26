using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLottery.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
        
        public int Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoPago { get; set; }
        public List<PagoDetalle> PagoDetalles { get; internal set; }
        public string? TokenWebpay { get; set; }
    }
}
