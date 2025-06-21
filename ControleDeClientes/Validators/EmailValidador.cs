using System.Net.Mail;

namespace ControleDeClientes.Validators {
    public class EmailValidador: IBaseValidador<string> {
        public bool Validador(string email, out string? erro) {

            MailAddress emailValido;

            try {
                emailValido = new MailAddress(email);
                erro = null;
                return true;
            }
            catch (FormatException) {
                erro = "Email inválido";
                return false;
            }
        }
        }
}
