using Microsoft.EntityFrameworkCore;

namespace TechLottery.Models
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Sorteo> Sorteos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistorialSorteo> HistorialSorteos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoDetalle> PagoDetalles { get; set; }
    }
    

}
