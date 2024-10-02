using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterTodos();
        Task<Endereco> ObterPorId(int id);
        Task Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task Remover(int id);
    }
}
