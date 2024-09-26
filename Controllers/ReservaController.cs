using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories;
using gerenciador_reservas_hotel.Repositories.Data;
using gerenciador_reservas_hotel.Services;

namespace gerenciador_reservas_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservasDbContext _context;
        private readonly ReservaService _reservaService;

        public ReservaController(ReservasDbContext context, ReservaService reservaService)
        {
            _context = context;
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDTO reservaDTO)
        {
            Reserva reserva = await _reservaService.CreateReserva(reservaDTO);

            return CreatedAtAction(nameof(PostReserva), new { id = reserva.Id }, reserva);
        }

    }

}
