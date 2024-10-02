using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories;
using gerenciador_reservas_hotel.Repositories.Data;

namespace gerenciador_reservas_hotel.Services
{
    public class ReservaService
    {
        private readonly ReservasDbContext _context;
        private readonly HospedeService _hospedeService;
        private readonly QuartoService _quartoService;
        private readonly ReservaRepository _reservaRepository;

        public ReservaService(
            ReservasDbContext context,
            HospedeService hospedeService,
            QuartoService quartoService,
            ReservaRepository reservaRepository
        )
        {
            _context = context;
            _hospedeService = hospedeService;
            _quartoService = quartoService;
            _reservaRepository = reservaRepository;
        }

        public async Task<Reserva> CreateReserva(ReservaDTO reservaDTO)
        {

            Hospede hospede = await _hospedeService.GetHospedeOrThrowError(reservaDTO.Hospede);
            if (!hospede.Ativo)
            {
                throw new InvalidOperationException("Hóspede inativo. Não é possível agendar a reserva.");
            }

            int quartoId = reservaDTO.Quarto.First().QuartoId;
            Quarto quarto = await _quartoService.GetQuartoOrThrowError(quartoId);
            bool quartoDisponivel = await _reservaRepository.IsQuartoDisponivel(quarto.Id, reservaDTO.DataReserva);

            if (!quartoDisponivel)
            {
                throw new InvalidOperationException("O quarto não está disponível para a data solicitada.");
            }

            Reserva reserva = new Reserva(
                quarto: quarto,
                hospede: hospede,
                dataCriacao: DateTime.Now,
                dataReservaDuracao: DateTime.Now.AddDays(1) // Adiciona 1 dia à data de criação
            );

            return await _reservaRepository.SaveReserva(reserva);
        }
    }
}
