namespace gerenciador_reservas_hotel.Models
{
    public class Reserva
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataReservaDuracao { get; set; }
        public Hospede Hospede { get; set; }    
        public Quarto Quarto { get; set; }

        private Reserva() { }

        public Reserva(Hospede hospede, Quarto quarto, DateTime dataCriacao, DateTime dataReservaDuracao)
        {
            Hospede = hospede;
            Quarto = quarto;
            DataCriacao = dataCriacao;
            DataReservaDuracao = dataReservaDuracao;
        }
    }
}
