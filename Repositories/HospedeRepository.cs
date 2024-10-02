using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_reservas_hotel.Repositories
{
    public class HospedeRepository
    {
        private readonly ReservasDbContext _context;

        public HospedeRepository (ReservasDbContext context)
        {
            _context = context;
        }

        public async Task<Hospede?> GetHospede(int hospedeId)
        {
            Hospede? hospede = await _context
                .Hospede
                .FirstOrDefaultAsync(q => q.Id == hospedeId);

            return hospede;
        }

        public async Task<Hospede> SaveHospede(Hospede hospede)
        {
            _context.Hospede.Add(hospede);
            await _context.SaveChangesAsync();
            return hospede;
        }
    }
}
