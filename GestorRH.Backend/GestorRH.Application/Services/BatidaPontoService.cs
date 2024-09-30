using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Dominio.ValueObjects;

namespace GestorRH.Application.Services
{
    public class BatidaPontoService : IBatidaPontoService
    {
        private readonly IBatidaPontoRepository _batidaPontoRepository;

        public BatidaPontoService(IBatidaPontoRepository batidaPontoRepository)
        {
            _batidaPontoRepository = batidaPontoRepository;
        }

        public Task<IEnumerable<BatidaPontoDTO>> ObterTodasBatidasPonto()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BatidaPontoDTO>> ObterBatidaPontoPorFuncionarioId(int funcionarioId)
        {
            var batidas = await _batidaPontoRepository.ObterPorFuncionarioId(funcionarioId);
            return batidas.Select(b => new BatidaPontoDTO
            {
                Id = b.Id,
                FuncionarioId = b.FuncionarioId,
                DataHora = b.DataHora,
                TipoBatida = b.TipoBatida.ToString()
            });
        }

        public async Task AdicionarBatidaPonto(BatidaPontoDTO batidaPontoDto)
        {
            var batidaPonto = new BatidaPonto(batidaPontoDto.FuncionarioId, batidaPontoDto.DataHora, Enum.Parse<TipoBatida>(batidaPontoDto.TipoBatida));
            await _batidaPontoRepository.Adicionar(batidaPonto);
        }

        public async Task AtualizarBatidaPonto(BatidaPontoDTO batidaPontoDto)
        {
            var batidaPonto = await _batidaPontoRepository.ObterPorId(batidaPontoDto.Id);
            if (batidaPonto != null)
            {
                batidaPonto.DataHora = batidaPontoDto.DataHora;
                batidaPonto.TipoBatida = Enum.Parse<TipoBatida>(batidaPontoDto.TipoBatida);
            }

            await _batidaPontoRepository.Atualizar(batidaPonto);
        }

        public async Task RemoverBatidaPonto(int id)
        {
            await _batidaPontoRepository.Remover(id);
        }
    }
}