using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLottery.DTOs;
using TechLottery.Models;

namespace TechLottery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteosController : ControllerBase
    {
        private readonly Context _context;

        public SorteosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SorteoResponseDto>>> GetSorteos()
        {
            return await _context.Sorteos.Select(x => new SorteoResponseDto
            {
                SorteoId = x.SorteoId,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                PrecioBoletos = x.PrecioBoletos,
                FechaInicio = x.FechaInicio,
                FechaFin = x.FechaFin,
                BoletosTotales = x.BoletosTotales,
                BoletosVendidos = x.BoletosVendidos,
                Imagen= x.Imagen
            }).ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SorteoResponseDto>> GetById(int id)
        {
            var sorteo = await _context.Sorteos.FirstOrDefaultAsync(p => p.SorteoId == id);

            if (sorteo == null)
            {
                return NotFound();
            }

            var sorteoDto = new SorteoResponseDto
            {
                SorteoId = sorteo.SorteoId,
                Nombre = sorteo.Nombre,
                Descripcion = sorteo.Descripcion,
                PrecioBoletos = sorteo.PrecioBoletos,
                FechaInicio = sorteo.FechaInicio,
                FechaFin = sorteo.FechaFin,
                BoletosTotales = sorteo.BoletosTotales,
                BoletosVendidos = sorteo.BoletosVendidos,
                Imagen= sorteo.Imagen
            };
            return Ok(sorteoDto);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]


        public async Task<ActionResult<SorteoResponseDto>> Add(SorteoRequestDto sorteoRequestDto)
        {
            var sorteo = new Sorteo
            {
                Nombre = sorteoRequestDto.Nombre,
                Descripcion = sorteoRequestDto.Descripcion,
                PrecioBoletos = sorteoRequestDto.PrecioBoletos,
                FechaInicio = sorteoRequestDto.FechaInicio,
                FechaFin = sorteoRequestDto.FechaFin,
                BoletosTotales = sorteoRequestDto.BoletosTotales,
                Imagen= sorteoRequestDto.Imagen
            };
            await _context.Sorteos.AddAsync(sorteo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = sorteo.SorteoId }, new SorteoResponseDto
            {
                SorteoId = sorteo.SorteoId,
                Nombre = sorteo.Nombre,
                Descripcion = sorteo.Descripcion,
                PrecioBoletos = sorteo.PrecioBoletos,
                FechaInicio = sorteo.FechaInicio,
                FechaFin = sorteo.FechaFin,
                BoletosTotales = sorteo.BoletosTotales,
                BoletosVendidos = sorteo.BoletosVendidos,
                Imagen = sorteo.Imagen
            });
        }

    }

    
}
