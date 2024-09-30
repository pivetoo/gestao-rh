using GestorRH.Application.DTOs;

namespace GestorRH.Dominio.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDTO>> ObterTodosFuncionarios();
        Task<FuncionarioDTO> ObterFuncionariosPorId(int id);
        Task<FuncionarioDTO> ObterFuncionarioPorCpf(string cpf);
        Task AdicionarFuncionario(FuncionarioDTO funcionarioDto);
        Task AtualizarFuncionario(FuncionarioDTO funcionarioDto);
        Task RemoverFuncionario(int id);
    }
}
