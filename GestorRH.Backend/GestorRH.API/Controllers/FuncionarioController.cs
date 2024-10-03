using GestorRH.Application.DTOs;
using GestorRH.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IWebHostEnvironment _env;

        public FuncionarioController(IFuncionarioService funcionarioService, IWebHostEnvironment env)
        {
            _funcionarioService = funcionarioService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFuncionarios()
        {
            var funcionarios = await _funcionarioService.ObterTodosFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFuncionarioById(int id)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorId(id);
            return Ok(funcionario);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetFuncionarioByCpf(string cpf)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPorCpf(cpf);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> PostFuncionario(FuncionarioDTO funcionarioDto)
        {
            await _funcionarioService.AdicionarFuncionario(funcionarioDto);
            return NoContent();
        }        

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutFuncionario(FuncionarioDTO funcionariosDto)
        {
            await _funcionarioService.AtualizarFuncionario(funcionariosDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            await _funcionarioService.RemoverFuncionario(id);
            return NoContent();
        }

        [HttpGet("count")]
        public async Task<IActionResult> ContarFuncionarios()
        {
            var totalFuncionarios = await _funcionarioService.ContarFuncionarios();
            return Ok(new { total = totalFuncionarios });
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            var imageUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

            return Ok(new { imageUrl });
        }
    }
}
