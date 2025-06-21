namespace ControleDeClientes.Validators {
    public class DataNascimentoValidador : IBaseValidador<string> {
        public bool Validador(string dataNascimento, out string? erro) {
            if(DataConversor.DataNacimentoVerificador(dataNascimento, out DateTime dataConvertida) == true) {
                erro = null;
                return true;
            }

            else { 
                
                erro = "Data de nascimento inválida";
                return false;
            }
        }
    }
}
