using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace GestorRH.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<EnderecoDTO>> ObterTodosEnderecos()
        {
            var enderecos = await _enderecoRepository.ObterTodos();

            return enderecos.Select(e => new EnderecoDTO
            {
                Id = e.Id,
                Numero = e.Numero,
                Cidade = e.Cidade,
                Estado = e.Estado,
                Cep = e.Cidade,
                Bairro = e.Bairro,
                Logradouro = e.Logradouro
            });
        }

        public async Task<EnderecoDTO> ObterEnderecoPorId(int id)
        {
            var enderecos = await _enderecoRepository.ObterPorId(id);

            return new EnderecoDTO
            {
                Id = enderecos.Id,
                Numero = enderecos.Numero,
                Cidade = enderecos.Cidade,
                Estado = enderecos.Estado,
                Cep = enderecos.Cidade,
                Bairro = enderecos.Bairro,
                Logradouro = enderecos.Logradouro
            };
        }

        public async Task AdicionarEndereco(EnderecoDTO enderecoDto)
        {
            var endereco = new Endereco
            {
                Numero = enderecoDto.Numero,
                Cidade = enderecoDto.Cidade,
                Estado = enderecoDto.Estado,
                Cep = enderecoDto.Cidade,
                Bairro = enderecoDto.Bairro,
                Logradouro = enderecoDto.Logradouro
            };

            await _enderecoRepository.Adicionar(endereco);
        }

        public async Task AtualizarEndereco(EnderecoDTO enderecoDto)
        {
            var endereco = await _enderecoRepository.ObterPorId(enderecoDto.Id);

            if (endereco != null)
            {
                endereco.Numero = enderecoDto.Numero;
                endereco.Cidade = enderecoDto.Cidade;
                endereco.Estado = enderecoDto.Estado;
                endereco.Cep = enderecoDto.Cidade;
                endereco.Bairro = enderecoDto.Bairro;
                endereco.Logradouro = enderecoDto.Logradouro;
            }

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task RemoverEndereco(int id)
        {
            await _enderecoRepository.Remover(id);
        }
    }
}
