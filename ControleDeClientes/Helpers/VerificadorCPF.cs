namespace ControleDeClientes.Helpers {
    internal class VerificadorCPF {

        public static bool ValidarCpf(string cpf) {

            cpf = cpf.Trim();
            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf) {
                return false;
            }

            bool primeiroDigitoValido = CalcularCPF(cpf, 8, 10, 1);
            bool segundoDigitoValido = CalcularCPF(cpf, 9, 11, 0);

            return primeiroDigitoValido && segundoDigitoValido;
        }
        private static bool CalcularCPF(string cpf, int tamanho, int multiplicador, int digito) {

            int soma = 0;
            for (int i = 0; i <= tamanho; i++) {
                soma += (cpf[i] - '0') * multiplicador;
                multiplicador--;
            }

            soma = soma * 10 % 11;

            if (soma >= 10) {
                soma = 0;
            }

            return soma == cpf[10 - digito] - '0';

        }
    }
}
