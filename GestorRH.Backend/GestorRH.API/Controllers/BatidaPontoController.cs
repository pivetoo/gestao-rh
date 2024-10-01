using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatidaPontoController : ControllerBase
    {
        private readonly IBatidaPontoService _batidaPontoService;

        public BatidaPontoController(IBatidaPontoService batidaPontoService)
        {
            _batidaPontoService = batidaPontoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBatidasPonto()
        {
            var batidasPonto = await _batidaPontoService.ObterTodasBatidasPonto();
            return Ok(batidasPonto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBatidaPontoById(int id)
        {
            var batidaPonto = await _batidaPontoService.ObterBatidaPontoPorFuncionarioId(id);
            return Ok(batidaPonto);
        }

        [HttpPost]
        public async Task<IActionResult> PostBatidaPonto(BatidaPontoDTO batidaPontoDto)
        {
            await _batidaPontoService.AdicionarBatidaPonto(batidaPontoDto);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutBatidaPonto(BatidaPontoDTO batidaPontoDto)
        {
            await _batidaPontoService.AtualizarBatidaPonto(batidaPontoDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBatidaPonto(int id)
        {
            await _batidaPontoService.RemoverBatidaPonto(id);
            return NoContent();
        }
    }
}
