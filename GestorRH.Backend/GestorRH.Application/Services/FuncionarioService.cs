﻿using GestorRH.Application.DTOs;
using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Dominio.Tools;

namespace GestorRH.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IEnumerable<FuncionarioDTO>> ObterTodosFuncionarios()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();

            return funcionarios.Select(f => new FuncionarioDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Cpf = f.Cpf,
                CargoId = f.CargoId,
                EnderecoId = f.EnderecoId,
                DataNascimento = f.DataNascimento,
                Email = f.Email,
                Telefone = f.Telefone,
                IsAdmin = f.IsAdmin
            });
        }

        public async Task<FuncionarioDTO> ObterFuncionarioPorId(int id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            return new FuncionarioDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf,
                DataNascimento = funcionario.DataNascimento,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                CargoId = funcionario.CargoId,
                DepartamentoId = funcionario.DepartamentoId,
                EnderecoId = funcionario.EnderecoId
            };
        }

        public async Task<Funcionario> ObterFuncionarioPeloEmail(string email)
        {
            return await _funcionarioRepository.ObterPeloEmail(email);
        }

        public async Task<FuncionarioDTO> ObterFuncionarioPorCpf(string cpf)
        {
            var funcionario = await _funcionarioRepository.ObterPorCpf(cpf);

            return new FuncionarioDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf,
                DataNascimento = funcionario.DataNascimento,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                CargoId = funcionario.CargoId,
                DepartamentoId = funcionario.DepartamentoId,
                EnderecoId = funcionario.EnderecoId
            };
        }

        public async Task AdicionarFuncionario(FuncionarioDTO funcionarioDto)
        {
            var funcionario = new Funcionario
            {
                Nome = funcionarioDto.Nome,
                Cpf = funcionarioDto.Cpf,
                DataNascimento = funcionarioDto.DataNascimento,
                CargoId = funcionarioDto.CargoId,
                DepartamentoId = funcionarioDto.DepartamentoId,
                EnderecoId = funcionarioDto.EnderecoId,
                Email = funcionarioDto.Email,
                Telefone = funcionarioDto.Telefone,
                Senha = PasswordHash.HashPassword(funcionarioDto.Senha),
                IsAdmin = funcionarioDto.IsAdmin
            };

            await _funcionarioRepository.Adicionar(funcionario);
        }

        public async Task AtualizarFuncionario(FuncionarioDTO funcionarioDto)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(funcionarioDto.Id);

            if (funcionario != null)
            {
                funcionario.Nome = funcionarioDto.Nome;
                funcionario.Cpf = funcionarioDto.Cpf;
                funcionario.DataNascimento = funcionarioDto.DataNascimento;
                funcionario.Email = funcionarioDto.Email;
                funcionario.Telefone = funcionarioDto.Telefone;
                funcionario.IsAdmin = funcionarioDto.IsAdmin;
            }

            await _funcionarioRepository.Atualizar(funcionario);
        }

        public async Task RemoverFuncionario(int id)
        {
            await _funcionarioRepository.Remover(id);
        }

        public async Task<int> ContarFuncionarios()
        {
            return await _funcionarioRepository.ContarFuncionarios();
        }
    }
}
