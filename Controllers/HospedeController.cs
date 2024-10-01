using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_reservas_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedeController : ControllerBase
    {
        private readonly ReservasDbContext _context;

        public HospedeController(ReservasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospede>>> GetQuarto()
        {
            return await _context.Hospede.ToListAsync();
        }
    }
}
