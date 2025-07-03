using ControleDeClientes.Helpers;

namespace ControleDeClientes.Validators {
    public class ValidadorCPF : IBaseValidador<string> {
        public bool Validador(string cpf, out string? erro) {

            if (VerificadorCPF.ValidarCpf(cpf)) {
                erro = null;
                return true;
            }
            else {
                erro = "CPF inválido";
                return false;
            }
        }
    }
}
