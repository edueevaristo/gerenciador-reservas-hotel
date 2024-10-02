using System.ComponentModel.DataAnnotations;

namespace gerenciador_reservas_hotel.Models
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Categoria { get; set; }
        public Quarto() { }

        public Quarto(int id, string numero, string categoria)
        {
            Id = id;
            Numero = numero;
            Categoria = categoria;
        }
    }
}
