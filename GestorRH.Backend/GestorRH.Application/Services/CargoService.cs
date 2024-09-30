using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;

namespace GestorRH.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<CargoDTO>> ObterTodosCargos()
        {
            var cargos = await _cargoRepository.ObterTodos();

            return cargos.Select(c => new CargoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                SalarioBase = c.SalarioBase,
                FuncionarioCount = c.Funcionarios.Count(),
            });
        }

        public async Task<CargoDTO> ObterCargoPorId(int id)
        {
            var cargo = await _cargoRepository.ObterPorId(id);

            return new CargoDTO
            {
                Id = cargo.Id,
                Nome = cargo.Nome,
                SalarioBase = cargo.SalarioBase,
                FuncionarioCount = cargo.Funcionarios.Count(),
            };
        }

        public async Task AdicionarCargo(CargoDTO cargoDto)
        {
            var cargo = new Cargo
            {
                Nome = cargoDto.Nome,
                SalarioBase = cargoDto.SalarioBase
            };

            await _cargoRepository.Adicionar(cargo);
        }

        public async Task AtualizarCargo(CargoDTO cargoDto)
        {
            var cargo = await _cargoRepository.ObterPorId(cargoDto.Id);

            if (cargo != null)
            {
                cargo.Nome = cargoDto.Nome;
                cargo.SalarioBase = cargoDto.SalarioBase;
            }

            await _cargoRepository.Atualizar(cargo);
        }

        public async Task RemoverCargo(int id)
        {
            await _cargoRepository.Remover(id);
        }
    }
}
