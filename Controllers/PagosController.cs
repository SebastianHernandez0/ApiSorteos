using Microsoft.AspNetCore.Mvc;
using TechLottery.Models;
using TechLottery.Services;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechLottery.Services.TechLottery.Services;

namespace TechLottery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly Context _context;
        private readonly MercadoPagoService _mercadoPagoService;

        public PagosController(Context context, IConfiguration configuration)
        {
            _context = context;
            var accessToken = Environment.GetEnvironmentVariable("MERCADOPAGO_AT");
            _mercadoPagoService = new MercadoPagoService(accessToken);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] CreatePagoRequest request)
        {
            // Crear el pago en la base de datos
            var pago = new Pago
            {
                UserId = request.UserId,
                FechaPago = DateTime.Now,
                EstadoPago = "Pendiente",
                PagoDetalles = request.PagoDetalles.Select(d => new PagoDetalle
                {
                    SorteoId = d.SorteoId,
                    Cantidad = d.Cantidad,
                    Monto = d.Monto
                }).ToList()
            };

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            // Crear la transacción en MercadoPago
            try
            {
                var amount = request.PagoDetalles.Sum(d => d.Monto); // Sumamos los montos de los detalles
                var description = "Compra de boletos";
                var email = "comprador@example.com"; // Reemplaza con el email del comprador

                var payment = await _mercadoPagoService.CreatePaymentAsync(amount, description, email);

                // Actualizar el pago con el ID de MercadoPago
                pago.TokenWebpay = payment.Id.ToString();
                pago.EstadoPago = "Iniciado";
                await _context.SaveChangesAsync();

                // Retornar la URL de redirección a MercadoPago
                return Ok(new { Url = payment.TransactionDetails.ExternalResourceUrl, Token = payment.Id });
            }
            catch (Exception ex)
            {
                // Manejar errores
                pago.EstadoPago = "Error";
                await _context.SaveChangesAsync();

                return StatusCode(500, new { Message = "Error al crear la transacción en MercadoPago", Error = ex.Message });
            }
        }

        // Otros métodos del controlador...

        public class CreatePagoRequest
        {
            public int UserId { get; set; }
            public List<PagoDetalleRequest> PagoDetalles { get; set; }
        }

        public class PagoDetalleRequest
        {
            public int SorteoId { get; set; }
            public int Cantidad { get; set; }
            public int Monto { get; set; }
        }
    }
}
