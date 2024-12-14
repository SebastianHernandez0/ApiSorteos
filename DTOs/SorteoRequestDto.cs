namespace TechLottery.DTOs
{
    public class SorteoRequestDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PrecioBoletos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int BoletosTotales { get; set; }
    }
}
