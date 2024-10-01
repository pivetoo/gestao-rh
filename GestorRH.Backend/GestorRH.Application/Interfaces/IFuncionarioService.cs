using GestorRH.Application.DTOs;
using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDTO>> ObterTodosFuncionarios();
        Task<FuncionarioDTO> ObterFuncionarioPorId(int id);
        Task<Funcionario> ObterFuncionarioPeloEmail(string email);
        Task<FuncionarioDTO> ObterFuncionarioPorCpf(string cpf);
        Task AdicionarFuncionario(FuncionarioDTO funcionarioDto);
        Task AtualizarFuncionario(FuncionarioDTO funcionarioDto);
        Task RemoverFuncionario(int id);
        Task<int> ContarFuncionarios();
    }
}
