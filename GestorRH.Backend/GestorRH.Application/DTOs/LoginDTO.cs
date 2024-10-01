using System.ComponentModel.DataAnnotations;

namespace GestorRH.Application.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
