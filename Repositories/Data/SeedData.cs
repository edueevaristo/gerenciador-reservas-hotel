using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.Models;

namespace gerenciador_reservas_hotel.Repositories.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReservasDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ReservasDbContext>>()))
            {
                if (!context.Hospede.Any())
                {
                    context.Hospede.AddRange(
                        new Hospede(id: 1, nome: "Jean", email: "jean@gmail.com", ativo: false),
                        new Hospede(id: 2, nome: "Eduardo", email: "eduardo@gmail.com", ativo: true),
                        new Hospede(id: 3, nome: "Daniel", email: "daniel@gmail.com", ativo: false)
                    );
                }

                if (!context.Quarto.Any())
                {
                    context.Quarto.AddRange(
                        new Quarto(id: 1, numero: "111", categoria: "Viagem"),
                        new Quarto(id: 2, numero: "222", categoria: "Turismo"),
                        new Quarto(id: 3, numero: "333", categoria: "Imigrante")
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
