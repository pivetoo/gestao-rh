using GestorRH.Application.DTOs;
using GestorRH.Dominio.Interfaces;
using GestorRH.Dominio.Tools;
using Microsoft.AspNetCore.Mvc;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IConfiguration _configuration;

        public AuthController(IFuncionarioService funcionarioService, IConfiguration configuration)
        {
            _funcionarioService = funcionarioService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var funcionario = await _funcionarioService.ObterFuncionarioPeloEmail(loginDto.Email);

            if (funcionario == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }            
            var token = JwtToken.GerarToken(funcionario, _configuration);

            var isAdmin = funcionario.IsAdmin;

            return Ok(new { token, isAdmin });
        }
    }
}
