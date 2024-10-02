namespace gerenciador_reservas_hotel.Models
{
    public class Hospede
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
        public bool Ativo { get; set;}

        public Hospede() { }

        public Hospede(int id, string nome, string email, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }

        public Hospede(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
