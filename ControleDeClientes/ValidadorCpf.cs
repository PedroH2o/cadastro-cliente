using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeClientes {
    internal class ValidadorCpf {

        // o primeiro tamanho tem que ser 8 e multiplicador 10
        // o segundo tamanho tem que ser 9 e multiplicador 11

        public static bool validarCpf(string cpf) {

            cpf = cpf.Trim();
            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf) {
                Console.WriteLine("CPF inválido");
                return false;
            }

            bool primeiroDigitoValido = calcularCPF(cpf, 8, 10, 1);
            bool segundoDigitoValido = calcularCPF(cpf, 9, 11, 0);

            return primeiroDigitoValido && segundoDigitoValido;
        }
        private static bool calcularCPF(string cpf, int tamanho, int multiplicador, int digito) {

            int soma = 0;
            for (int i = 0; i <= tamanho; i++) {
                soma += (cpf[i] - '0') * multiplicador;
                multiplicador--;
            }

            soma = (soma * 10) % 11;

            if (soma >= 10) {
                soma = 0;
            }

            return soma == (cpf[10 - digito]) - '0';

        }
    }
}
