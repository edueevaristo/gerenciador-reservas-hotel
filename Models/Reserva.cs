namespace gerenciador_reservas_hotel.Models
{
    public class Reserva
    {
        public string Id { get; set; }
        public DateTime data { get; set; }
        public Hospede Hospede { get; set; }    
        public Quarto Quarto { get; set; }

        public void RealizarReserva(Hospede hospede, Quarto quarto)
        {
            Hospede = hospede;
            Quarto = quarto;
        }
    }
}
