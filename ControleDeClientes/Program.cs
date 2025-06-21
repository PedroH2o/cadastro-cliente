using ControleDeClientes;
using ControleDeClientes.Context;
using ControleDeClientes.DTOs;
using ControleDeClientes.Map;
using ControleDeClientes.Models;
using ControleDeClientes.Repositories;
using ControleDeClientes.Validators;

class Program {
    
    static async Task Main(string[] args) {

        

        var context = new AppDbContext();
        var repositorio = new ClienteRepository(context);

        
    }
}
