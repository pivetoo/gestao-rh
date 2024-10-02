using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var endereco = await _enderecoService.ObterTodosEnderecos();
            return Ok(endereco);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var endereco = await _enderecoService.ObterEnderecoPorId(id);
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> PostEndereco(EnderecoDTO enderecoDto)
        {
            await _enderecoService.AdicionarEndereco(enderecoDto);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEndereco(EnderecoDTO enderecoDto)
        {
            await _enderecoService.AtualizarEndereco(enderecoDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            await _enderecoService.RemoverEndereco(id);
            return NoContent();
        }
    }
}
