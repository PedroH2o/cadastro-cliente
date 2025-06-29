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
 
        int op = 6;
        string id = " ";

        while (op != 0 ) {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] opcoes = {
                "MENU PRINCIPAL",
                "(1) Cadastrar",
                "(2) Remover",
                "(3) Editar",
                "(4) Lista completa de clientes",
                "(0) Sair"
            };

            int largura = 36;
            string bordaSup = "┌" + new string('─', largura) + "┐";
            string bordaInf = "└" + new string('─', largura) + "┘";

            Console.WriteLine(bordaSup);

            foreach (string opcao in opcoes) {
                string linha = "│ " + opcao.PadRight(largura - 1) + "│";
                Console.WriteLine(linha);
            }

            Console.WriteLine(bordaInf);
            Console.Write("Digite sua opção: ");
            op = int.Parse(Console.ReadLine());

            switch (op) {

                case 0: 

                    break;

                case 1: // Adiciona Cliente

                    Console.WriteLine("Digite as informações para cadastro:");

                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("CPF (Apenas números): ");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("email: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Data de Nascimento (dd/MM/aaaa): ");
                    string nascimento = Console.ReadLine();

                    var ClienteDto = new ClienteDTO {
                        Nome = nome,
                        Cpf = cpf,
                        Email = email,
                        DataNascimento = nascimento
                    };


                    var erros = ValidatorCliente.ValidarCliente(ClienteDto);

                    if (erros.Count == 0) {

                        var cli = ClienteMap.TransferidorDeDados(ClienteDto);
                        await repositorio.AddCliente(cli);
                        Console.WriteLine("Sucesso");
                    }
                    else {
                        Console.WriteLine("Foram encontrados os seguintes erros:");
                        foreach (var erro in erros) {
                            Console.WriteLine($"- {erro}");
                        }
                    }

                    break;

                case 2: // Remove Cliente

                    Console.WriteLine("Informe o ID para remoção: ");
                    id = Console.ReadLine();
                    Guid clienteID = new(id);

                    var sucesso = await repositorio.RemoverCliente(clienteID);

                    if (sucesso) {
                        Console.WriteLine("Removido com sucesso");
                    }
                    else {
                        Console.WriteLine("Falhou");
                    }
                    break;
                
                case 3: // Edita Cliente

                    Console.WriteLine("Informe o ID para remoção: ");
                    id = Console.ReadLine(); 

                    Guid clienteIID = new(id);
                    var cliente = await repositorio.BuscarClientePorID(clienteIID);

                    Console.WriteLine("Digite as novas informações:");

                    Console.WriteLine("Nome: ");
                    string nomeEd = Console.ReadLine();

                    Console.WriteLine("CPF (Apenas números): ");
                    string cpfEd = Console.ReadLine();

                    Console.WriteLine("email: ");
                    string emailEd = Console.ReadLine();

                    Console.WriteLine("Data de Nascimento (dd/MM/aaaa): ");
                    string nascimentoEd = Console.ReadLine();

                    var ClienteDtoEd = new ClienteDTO {
                        Nome = nomeEd,
                        Cpf = cpfEd,
                        Email = emailEd,
                        DataNascimento = nascimentoEd
                    };
                    var erross = ValidatorCliente.ValidarCliente(ClienteDtoEd);

                    if (erross.Count == 0) {

                        var clis = ClienteMap.TransferidorDeDados(ClienteDtoEd);
                        await repositorio.EditarCliente(clis);
                        Console.WriteLine("Sucesso");
                    }
                    else {
                        Console.WriteLine("Foram encontrados os seguintes erros:");
                        foreach (var erro in erross) {
                            Console.WriteLine($"- {erro}");
                        }
                    }
                    break;

                case 4: // Lista clientes

                    var clientes = await repositorio.ListarClientes();

                    foreach (var c in clientes) {
                        Console.WriteLine($"ID: {c.Id}");
                        Console.WriteLine($"Nome: {c.Nome}");
                        Console.WriteLine($"Email: {c.Email}");
                        Console.WriteLine($"CPF: {c.Cpf}");
                        Console.WriteLine($"Nascimento: {c.DataNascimento:dd/MM/yyyy}");
                        Console.WriteLine(new string('-', 40));
                    }

                    break;

            }
        }
    }
}
