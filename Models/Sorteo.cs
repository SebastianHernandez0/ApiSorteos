using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLottery.Models
{
    public class Sorteo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SorteoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PrecioBoletos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int BoletosTotales { get; set; }
        public int BoletosVendidos { get; set; }
    }
}
