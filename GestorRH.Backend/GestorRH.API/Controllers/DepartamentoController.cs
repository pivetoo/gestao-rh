using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartamentos()
        {
            var departamentos = await _departamentoService.ObterTodosDepartamentos();
            return Ok(departamentos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartamentoById(int id)
        {
            var departamento = await _departamentoService.ObterDepartamentosPorId(id);
            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartamento(DepartamentoDTO departamentoDto)
        {
            await _departamentoService.AdicionarDepartamento(departamentoDto);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDepartamento(DepartamentoDTO departamentoDto)
        {
            await _departamentoService.AtualizarDepartamento(departamentoDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoverDepartamento(int id)
        {
            await _departamentoService.RemoverDepartamento(id);
            return NoContent();
        }
    }
}
