namespace ControleDeClientes.Validators {
    public interface IBaseValidador<T> {
        bool Validador(T valor, out string? erro);
    }
}
