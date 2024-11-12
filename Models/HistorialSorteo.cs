using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLottery.Models
{
    public class HistorialSorteo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorialId { get; set; }
        public int SorteoId { get; set; }
        [ForeignKey("SorteoId")]
        public Sorteo Sorteo { get; set; }
        public int GanadorId { get; set; }
        [ForeignKey("GanadorId")]
        public Usuario Ganador { get; set; }
        public DateTime FechaGanado { get; set; }
    }
}
