using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories;
using gerenciador_reservas_hotel.Repositories.Data;

namespace gerenciador_reservas_hotel.Services
{
    public class HospedeService
    {
        private readonly HospedeRepository _hospedeRepository;

        public HospedeService(HospedeRepository hospedeRepository)
        {
            _hospedeRepository = hospedeRepository;
        }

        public async Task<Hospede> GetHospedeOrThrowError(int hospedeId)
        {
            Hospede hospede = await _hospedeRepository.GetHospede(hospedeId);

            if (hospede == null)
            {
                throw new Exception("Hospede não encontrados");
            }

            return hospede;
        }

        internal async Task<Hospede> GetHospedeOrThrowError(ICollection<HospedeDTO> hospedes)
        {
            if (hospedes == null || !hospedes.Any())
            {
                throw new ArgumentException("A coleção de hóspedes não pode ser nula ou vazia.");
            }

            var hospedeId = hospedes.First().HospedeId;

            return await GetHospedeOrThrowError(hospedeId);
        }

        public async Task<Hospede> CreateHospede(HospedeDTO hospedeDTO)
        {
            if (hospedeDTO == null)
            {
                throw new ArgumentNullException("Erro ao tentar registrar o hóspede");
            }

            var hospede = new Hospede
            {
                Id = hospedeDTO.HospedeId,
                Nome = hospedeDTO.Nome,
                Email = hospedeDTO.Email,
                Ativo = hospedeDTO.Ativo
            };

            return await _hospedeRepository.SaveHospede(hospede);
        }
    }
}
