using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories;
using gerenciador_reservas_hotel.Repositories.Data;

namespace gerenciador_reservas_hotel.Services
{
    public class QuartoService
    {
        private readonly QuartoRepository _quartoRepository;

        public QuartoService(QuartoRepository quartoRepository)
        {
            _quartoRepository = quartoRepository;
        }

        public async Task<Quarto> GetQuartoOrThrowError(int quartoId)
        {
            Quarto quartos = await _quartoRepository.GetQuarto(quartoId);

            if (quartos == null)
            {
                throw new Exception("Quartos não encontrados");
            }

            return quartos;
        }
    }
}
