using ControleDeClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
