using Microsoft.EntityFrameworkCore;
using gerenciador_reservas_hotel.Repositories.Data;
using gerenciador_reservas_hotel.Services;
using gerenciador_reservas_hotel.Repositories;

namespace gerenciador_reservas_hotel
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ReservasDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                       .EnableSensitiveDataLogging() // Para logar dados sensíveis
                       .LogTo(Console.WriteLine, LogLevel.Information) // Log detalhado para console
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<HospedeService>();
            builder.Services.AddScoped<QuartoService>();
            builder.Services.AddScoped<ReservaService>();

            builder.Services.AddScoped<HospedeRepository>();
            builder.Services.AddScoped<QuartoRepository>();
            builder.Services.AddScoped<ReservaRepository>();
        }
        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void SeedOnInitialize(WebApplication app)
        {
            // Configura o banco de dados com dados de seed
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ReservasDbContext>();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    // Log error
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                InitializeSwagger(app);
            }

            SeedOnInitialize(app);

            app.MapControllers();

            app.Run();
        }
    }
}
