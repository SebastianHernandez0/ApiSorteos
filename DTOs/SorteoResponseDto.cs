namespace TechLottery.DTOs
{
    public class SorteoResponseDto
    {
        public int SorteoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PrecioBoletos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int BoletosTotales { get; set; }
        public int BoletosVendidos { get; set; }
        public string Imagen { get; set; }
    }
}
