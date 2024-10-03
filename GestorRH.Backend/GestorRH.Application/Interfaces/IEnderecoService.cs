using GestorRH.Application.DTOs;

namespace GestorRH.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoDTO>> ObterTodosEnderecos();
        Task<EnderecoDTO> ObterEnderecoPorId(int id);
        Task AdicionarEndereco(EnderecoDTO enderecoDto);
        Task AtualizarEndereco(EnderecoDTO enderecoDto);
        Task RemoverEndereco(int id);
    }
}
