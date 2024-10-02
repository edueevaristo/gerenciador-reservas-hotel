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

        public async Task<Quarto> CreateQuarto(QuartoDTO quartoDTO)
        {
            if (quartoDTO == null)
            {
                throw new ArgumentNullException("Erro ao tentar registrar o quarto");
            }

            var quarto = new Quarto
            {
                Id = quartoDTO.QuartoId,
                Categoria = quartoDTO.Categoria,
                Numero = quartoDTO.Numero
            };

            return await _quartoRepository.SaveQuarto(quarto);
        }
    }
}
