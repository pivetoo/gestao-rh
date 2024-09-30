using GestorRH.Application.DTOs;

namespace GestorRH.Application.Interfaces
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoDTO>> ObterTodosCargos();
        Task<CargoDTO> ObterCargoPorId(int id);
        Task AdicionarCargo(CargoDTO cargoDto);
        Task AtualizarCargo(CargoDTO cargoDto);
        Task RemoverCargo(int id);
    }
}
