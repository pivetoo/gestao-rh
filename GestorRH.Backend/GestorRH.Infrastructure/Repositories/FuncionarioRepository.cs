using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> ObterPorId(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task<Funcionario> ObterPeloEmail(string email)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(m => m.Email == email);
        }

        public async Task<Funcionario> ObterPorCpf(string cpf)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Cpf == cpf);
        }

        public async Task Adicionar(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var funcionario = await ObterPorId(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ContarFuncionarios()
        {
            return await _context.Funcionarios.CountAsync();
        }
    }
}
