using GestorRH.Application.DTOs;

namespace GestorRH.Application.Interfaces
{
    public interface IBatidaPontoService
    {
        Task<IEnumerable<BatidaPontoDTO>> ObterTodasBatidasPonto();
        Task<IEnumerable<BatidaPontoDTO>> ObterBatidaPontoPorFuncionarioId(int funcionarioId);
        Task AdicionarBatidaPonto(BatidaPontoDTO batidaPontoDto);
        Task AtualizarBatidaPonto(BatidaPontoDTO batidaPontoDto);
        Task RemoverBatidaPonto(int id);
    }
}