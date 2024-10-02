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
    public class HospedeController : ControllerBase
    {
        private readonly ReservasDbContext _context;
        private readonly HospedeService _hospedeService;

        public HospedeController(ReservasDbContext context, HospedeService hospedeService)
        {
            _context = context;
            _hospedeService = hospedeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospede>>> GetHospedes()
        {
            return await _context.Hospede.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Hospede>> PostHospede(HospedeDTO hospedeDTO)
        {
            if (hospedeDTO == null)
            {
                return BadRequest("Dados do hóspede inválidos.");
            }

            Hospede hospede = await _hospedeService.CreateHospede(hospedeDTO);

            return CreatedAtAction(nameof(GetHospedes), new { id = hospede.Id }, hospede);
        }
    }
}
