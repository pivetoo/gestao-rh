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

            CookieOptions options = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(30)
            };

            var token = JwtToken.GerarToken(funcionario, _configuration);

            Response.Cookies.Append("AuthToken", token, options);

            var isAdmin = funcionario.IsAdmin;

            return Ok(new { token, isAdmin });
        }

        [HttpGet("perfil")]
        public IActionResult GetCookie()
        {
            if (Request.Cookies.TryGetValue("AuthToken", out string token))
            {
                return Ok(new { token });
            }

            return Unauthorized("Token de autenticação não encontrado.");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return Ok(new { mensagem = "Logout realizado com sucesso!" });
        }
    }
}
