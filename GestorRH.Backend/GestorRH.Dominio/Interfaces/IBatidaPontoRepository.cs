using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface IBatidaPontoRepository
    {
        Task<IEnumerable<BatidaPonto>> ObterTodos();
        Task<BatidaPonto> ObterPorId(int id);
        Task<IEnumerable<BatidaPonto>> ObterPorFuncionarioId(int funcionarioId);
        Task Adicionar(BatidaPonto batidaPonto);
        Task Atualizar(BatidaPonto batidaPonto);
        Task Remover(int id);
    }
}