using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> ObterPorId(int id);
        Task<IEnumerable<Funcionario>> ObterTodos();
        Task<Funcionario> ObterPeloEmail(string email);
        Task<Funcionario> ObterPorCpf(string cpf);
        Task Adicionar(Funcionario funcionario);
        Task Atualizar(Funcionario funcionario);
        Task Remover(int id);
        Task<int> ContarFuncionarios();
    }
}
