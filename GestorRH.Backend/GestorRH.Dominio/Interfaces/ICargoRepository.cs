using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> ObterTodos();
        Task<Cargo> ObterPorId(int id);
        Task Adicionar(Cargo cargo);
        Task Atualizar(Cargo cargo);
        Task Remover(int id);
    }
}
