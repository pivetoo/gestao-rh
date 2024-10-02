using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> ObterTodos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> ObterPorId(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task Adicionar(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var endereco = await ObterPorId(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
