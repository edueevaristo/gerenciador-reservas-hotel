using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.Models;

namespace gerenciador_reservas_hotel.Repositories.Data;

public partial class ReservasDbContext : DbContext
{
    public DbSet<Quarto> Quarto { get; set; }
    public DbSet<Hospede> Hospede { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    public ReservasDbContext()
    {
    }

    public ReservasDbContext(DbContextOptions<ReservasDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci");
            //.HasCharSet("utf8mb4");

        modelBuilder.Entity<Quarto>().HasKey(c => c.Id);
        modelBuilder.Entity<Quarto>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Reserva>().HasKey(c => c.Id);
        modelBuilder.Entity<Reserva>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Hospede>().HasKey(c => c.Id);
        modelBuilder.Entity<Hospede>().Property(c => c.Id).ValueGeneratedOnAdd();


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
