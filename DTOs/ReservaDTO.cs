namespace gerenciador_reservas_hotel.DTOs
{
    public class ReservaDTO
    {
        public string ReservaId { get; set; }
        public ICollection<HospedeDTO> Hospede { get; set; }
        public ICollection<QuartoDTO> Quarto { get; set; }
        public DateTime DataReserva { get; set; }
    }
}
