using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TechLottery.DTOs;
using TechLottery.Models;

namespace TechLottery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class UsuariosController : ControllerBase
    {
        private readonly Context _context;
        private IValidator<UsuarioRequestDto> _usuarioRegisterValidator;


        public UsuariosController(Context context, IValidator<UsuarioRequestDto> usuarioRegisterValidator)
        {
            _context = context;
            _usuarioRegisterValidator = usuarioRegisterValidator;
        }

      
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            
            return await _context.Usuarios.ToListAsync();
        }

 
        [HttpGet("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

 
        [HttpPost("Register")]
        
        public async Task<ActionResult<UsuarioResponseDto>> Register(UsuarioRequestDto usuarioRequestDto)
        {
            var validationResult = _usuarioRegisterValidator.Validate(usuarioRequestDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { Errors = errors });

            }
            var usuarioExistente = await _context.Usuarios.SingleOrDefaultAsync(u => u.Correo == usuarioRequestDto.Correo);
            if (usuarioExistente != null)
            {
                return BadRequest("Usuario ya existe");
            }
            var hashedPassword= BCrypt.Net.BCrypt.HashPassword(usuarioRequestDto.Password);

            var usuario = new Usuario
            {
                Nombre = usuarioRequestDto.Nombre,
                Correo = usuarioRequestDto.Correo,
                Password = hashedPassword,
                Telefono = usuarioRequestDto.Telefono,
                Instagram = usuarioRequestDto.Instagram,
                Rol = "Usuario",
                FechaRegistro = DateTime.Now
            };


            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioDto = new UsuarioResponseDto
            {
                UserId = usuario.UserId,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                FechaRegistro = usuario.FechaRegistro,
                Telefono = usuario.Telefono,
                Instagram = usuario.Instagram,
                Rol = usuario.Rol
            };

            return CreatedAtAction("GetUsuario", new { id = usuario.UserId }, usuarioDto);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UsuarioLoginDto loginDto)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Correo == loginDto.Correo);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.Password))
            {
                return Unauthorized("Credenciales invalidas");
            }
            
            var token = GenerateJwtToken(usuario);
            var rol = usuario.Rol;
            var userId = usuario.UserId;
            var response = new { token, rol, userId };
            return Ok(response);


        }


  
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UserId == id);
        }
        private string GenerateJwtToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Correo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.UserId.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
