namespace TechLottery.DTOs
{
    public class UsuarioResponseDto
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int Telefono { get; set; }
        public string Instagram { get; set; } = string.Empty;
        public string Rol { get; set; }
    }
}
