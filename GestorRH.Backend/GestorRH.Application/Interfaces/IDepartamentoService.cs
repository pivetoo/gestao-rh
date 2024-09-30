using GestorRH.Application.DTOs;

namespace GestorRH.Application.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoDTO>> ObterTodosDepartamentos();
        Task<DepartamentoDTO> ObterDepartamentosPorId(int id);
        Task AdicionarDepartamento(DepartamentoDTO departamentoDto);
        Task AtualizarDepartamento(DepartamentoDTO departamentoDto);
        Task RemoverDepartamento(int id);
    }
}