﻿namespace GestorRH.Application.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool IsAdmin { get; set; }
        public string Senha { get; private set; }
    }
}
