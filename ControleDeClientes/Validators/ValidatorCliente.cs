using ControleDeClientes.DTOs;

namespace ControleDeClientes.Validators {
    public class ValidatorCliente {

        public static List<string> ValidarCliente(ClienteDTO cliente) {

            var erros = new List<string>();


            var nomeValidador = new NomeValidador();

            if (!nomeValidador.Validador(cliente.Nome, out var erroNome)) {
                erros.Add(erroNome);
            }

            var CpfValidador = new ValidadorCPF();
            if (!CpfValidador.Validador(cliente.Cpf, out var erroCpf)) {
                erros.Add(erroCpf);
            }

            var EmailValidador = new EmailValidador();
            if (!EmailValidador.Validador(cliente.Email, out var erroEmail)) {
                erros.Add(erroEmail);
            }

            var DataNascimentoValidador = new DataNascimentoValidador();
            if (!DataNascimentoValidador.Validador(cliente.DataNascimento, out var erroDataNascimento)) {
                erros.Add(erroDataNascimento);
            }

            return erros;
        }

    }
}
