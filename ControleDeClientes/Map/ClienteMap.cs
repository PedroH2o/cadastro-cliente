using ControleDeClientes.DTOs;
using ControleDeClientes.Helpers;
using ControleDeClientes.Models;

namespace ControleDeClientes.Map {
    public static class ClienteMap {

        public static EntityCliente TransferidorDeDados(ClienteDTO clienteDTO) {

            return new EntityCliente {
                Nome = clienteDTO.Nome,
                Cpf = clienteDTO.Cpf,
                Email = clienteDTO.Email,
                DataNascimento = DataConversor.DataNascimentoConvertida(clienteDTO.DataNascimento).ToUniversalTime(),
            };
        }
    }
}