
namespace ControleDeClientes.Models {
    public class EntityCliente {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
