namespace ControleDeClientes {
    public class DataConversor {
        public static bool DataNacimentoVerificador(string data_nascimento, out DateTime dataConvertida) {

            return DateTime.TryParseExact(
                data_nascimento,
                 "dd/MM/yyyy",
                 null,
                 System.Globalization.DateTimeStyles.AllowWhiteSpaces,
                 out dataConvertida);

        }

        public static DateTime DataNascimentoConvertida(string data_nascimento) {

            return DateTime.ParseExact(
                data_nascimento,
                 "dd/MM/yyyy",
                 null,
                 System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }
    }
        
}
