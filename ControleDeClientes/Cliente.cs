using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeClientes
{
    internal class Cliente
    {
        private string _nome;
        private string _cpf;
        private string _email;
        public DateTime DataNascimento { get; private set; }
        public int Id { get; private set; }

        public Cliente(string nome, string cpf, string email, string data_nascimento)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;

            // tipo.TryParseExact - Converte para o tipo antes do ponto
            // data_nascimento - a variável que será convertida
            // dd/MM/yyyy - o formato para o qual será convertido
            // null - O IFormatProvider que define um formato específico por país, como é null então será padrão do sistema
            // System.Globalization.DateTimeStyles.AllowWhiteSpaces Diz que vai ignorar espaços em branco
            // out DateTime dataNascimento Define a saída após a conversão, a data convertida será armazenada na variável dataNascimento

            bool conveter_data = DateTime.TryParseExact(data_nascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out DateTime dataNascimento);

            if (conveter_data)
            {
                DataNascimento = dataNascimento;
            }
            else
            {
                throw new ArgumentException("Data inválida. Exemplo de data válida: 03/02/2004");
            }

        }

        public string Nome
        {
            get { return _nome; }
            set
            { 
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) // Método que verifica se string é vazia ou nula
                {
                    _nome = value;
                }
                else
                {
                   throw new ArgumentException("Nome não pode ser vazio");
                }
            }

        }

        public string Cpf
        {
            get { return _cpf; }
            set {

                if (!ValidadorCpf.validarCpf(value)){
                    _cpf = value;
                }
               
                    throw new ArgumentException("CPF Inválido");
                
            }
        }

        public string Email
        {
            get { return _email; }
            set 
            {
                if (value.Contains('@'))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email inválido");
                }       
            }
        }

        public int CalcularIdade()
        {
            DateTime data_atual = DateTime.Today;

            int idade = data_atual.Year - DataNascimento.Year;

            if (DataNascimento.Date > data_atual.AddYears(-idade))
            {
                idade--;
            }

            
            return idade; 
        }

        public bool VerificarIdade()
        {
            if (CalcularIdade() < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
