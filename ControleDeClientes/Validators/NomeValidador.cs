namespace ControleDeClientes.Validators {
    public class NomeValidador : IBaseValidador<string> {
        public bool Validador(string nome, out string? erro) {

            if (!string.IsNullOrWhiteSpace(nome)) {
                erro = null;
                return true;
            }
            else {
                erro = "Nome não pode ser vazio";
                return false;
            }
        }
    }
}
