using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Repositories
{
    public class BatidaPontoRepository : IBatidaPontoRepository
    {
        private readonly ApplicationDbContext _context;

        public BatidaPontoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatidaPonto>> ObterTodos()
        {
            return await _context.BatidasPonto.ToListAsync();
        }

        public async Task<BatidaPonto> ObterPorId(int id)
        {
            return await _context.BatidasPonto.FindAsync(id);
        }

        public async Task<IEnumerable<BatidaPonto>> ObterPorFuncionarioId(int funcionarioId)
        {
            return await _context.BatidasPonto.Where(bp => bp.FuncionarioId == funcionarioId).ToListAsync();
        }

        public async Task Adicionar(BatidaPonto batidaPonto)
        {
            await _context.BatidasPonto.AddAsync(batidaPonto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(BatidaPonto batidaPonto)
        {
            _context.BatidasPonto.Update(batidaPonto);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var batidaPonto = await ObterPorId(id);
            _context.BatidasPonto.Remove(batidaPonto);
            await _context.SaveChangesAsync();
        }
    }
}