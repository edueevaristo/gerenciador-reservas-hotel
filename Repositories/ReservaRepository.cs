using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories.Data;
using Microsoft.EntityFrameworkCore;


namespace gerenciador_reservas_hotel.Repositories
{
    public class ReservaRepository
    {
        private readonly ReservasDbContext _context;

        public ReservaRepository (ReservasDbContext context)
        {
            _context = context;
        }

        public async Task <Reserva> SaveReserva (Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> IsQuartoDisponivel(int quartoId, DateTime dataReserva)
        {
            
            return !await _context.Reservas.AnyAsync(r => r.Quarto.Id == quartoId &&
                               r.DataCriacao <= dataReserva &&
                               r.DataReservaDuracao > dataReserva);
        }

    }
}
