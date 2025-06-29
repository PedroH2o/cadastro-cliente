using ControleDeClientes.Context;
using ControleDeClientes.Models;
using Microsoft.EntityFrameworkCore;


namespace ControleDeClientes.Repositories {
    public class ClienteRepository {

        // Guarda a o contexto do banco para realizar operações
        private readonly AppDbContext _context;

        // Contrutor para facilitar o uso de operações no banco de dados
        public ClienteRepository(AppDbContext context) { 
            _context = context;
        }

        // Cria uma tarefa assíncrona para operações no banco e será usado no program.cs
        public async Task AddCliente(EntityCliente cliente) {

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoverCliente(Guid id) {

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente is null) {

                return false;
            }
            else { 
                 _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;

            }

        }
            
        public async Task<bool> EditarCliente(EntityCliente cliente) {

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task <List<EntityCliente>> ListarClientes() {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<EntityCliente?> BuscarClientePorID(Guid id) {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
