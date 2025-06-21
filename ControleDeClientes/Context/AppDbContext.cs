using ControleDeClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeClientes.Context {
    public class AppDbContext : DbContext {
        public DbSet<EntityCliente> Clientes { get; set; }

        // Criando a connection string
        private readonly string _connectionString;

        // Lendo o Json com o caminho para o banco
        public AppDbContext() {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Armazenando o caminho do Json dentro da connection string
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Conectando com o banco usando connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
