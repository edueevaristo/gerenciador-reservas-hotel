using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_reservas_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        private readonly ReservasDbContext _context;

        public QuartoController(ReservasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuarto()
        {
            return await _context.Quarto.ToListAsync();
        }
    }
}
