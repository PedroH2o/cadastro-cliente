using ControleDeClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeClientes.Context {
    public class AppDbContext : DbContext {
        public DbSet<EntityCliente> Clientes { get; set; }

        // Conectando com o banco usando connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "clientes.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

        }

    }
}
