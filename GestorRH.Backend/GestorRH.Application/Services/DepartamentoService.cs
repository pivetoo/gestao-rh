using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;

namespace GestorRH.Application.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<DepartamentoDTO>> ObterTodosDepartamentos()
        {
            var departamentos = await _departamentoRepository.ObterTodos();

            return departamentos.Select(d => new DepartamentoDTO
            {
                Id = d.Id,
                Nome = d.Nome,
                FuncionarioCount = d.Funcionarios.Count()
            });
        }

        public async Task<DepartamentoDTO> ObterDepartamentosPorId(int id)
        {
            var departamento = await _departamentoRepository.ObterPorId(id);

            return new DepartamentoDTO
            {
                Id = id,
                Nome = departamento.Nome,
                FuncionarioCount = departamento.Funcionarios.Count(),
            };
        }

        public async Task AdicionarDepartamento(DepartamentoDTO departamentoDto)
        {
            var departamento = new Departamento
            {
                Nome = departamentoDto.Nome,
            };

            await _departamentoRepository.Adicionar(departamento);
        }

        public async Task AtualizarDepartamento(DepartamentoDTO departamentoDto)
        {
            var departamento = await _departamentoRepository.ObterPorId(departamentoDto.Id);
            if (departamento != null)
            {
                departamento.Nome = departamentoDto.Nome;
            }

            await _departamentoRepository.Atualizar(departamento);
        }

        public async Task RemoverDepartamento(int id)
        {
            await _departamentoRepository.Remover(id);
        }
    }
}