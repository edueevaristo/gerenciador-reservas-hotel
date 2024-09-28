using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_reservas_hotel.Repositories
{
    public class QuartoRepository
    {
        private readonly ReservasDbContext _context;

        public QuartoRepository (ReservasDbContext context)
        {
            _context = context;
        }
        
        public async Task<Quarto?> GetQuarto(int quartoId)
        {
            Quarto? quarto = await _context
                .Quarto
                .FirstOrDefaultAsync(q => q.Id == quartoId);
                
            return quarto;
        }
    }
}
