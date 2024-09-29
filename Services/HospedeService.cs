using gerenciador_reservas_hotel.DTOs;
using gerenciador_reservas_hotel.Models;
using gerenciador_reservas_hotel.Repositories;

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

        internal async Task<Hospede> GetHospedeOrThrowError(ICollection<HospedeDTO> hospede)
        {
            throw new NotImplementedException();
        }
    }
}
