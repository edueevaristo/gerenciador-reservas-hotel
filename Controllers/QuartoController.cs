using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using gerenciador_reservas_hotel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gerenciador_reservas_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        private readonly ReservasDbContext _context;
        private readonly QuartoService _quartoService;

        public QuartoController(ReservasDbContext context, QuartoService quartoService)
        {
            _context = context;
            _quartoService = quartoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos()
        {
            return await _context.Quarto.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Quarto>> PostQuarto(QuartoDTO quartoDTO)
        {
            if (quartoDTO == null)
            {
                return BadRequest("Dados do quarto inválidos.");
            }

            Quarto quarto = await _quartoService.CreateQuarto(quartoDTO);

            return CreatedAtAction(nameof(GetQuartos), new { id = quarto.Id }, quarto);
        }
    }
}
