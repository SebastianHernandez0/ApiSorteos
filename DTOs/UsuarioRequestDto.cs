namespace TechLottery.DTOs
{
    public class UsuarioRequestDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int Telefono { get; set; }
        public string Instagram { get; set; } = string.Empty;
    }
}
