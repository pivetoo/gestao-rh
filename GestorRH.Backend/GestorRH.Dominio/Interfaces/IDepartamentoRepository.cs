using GestorRH.Dominio.Entities;

namespace GestorRH.Dominio.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> ObterTodos();
        Task<Departamento> ObterPorId(int id);
        Task Adicionar(Departamento departamento);
        Task Atualizar(Departamento departamento);
        Task Remover(int id);
    }
}
