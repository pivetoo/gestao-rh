using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> ObterTodos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> ObterPorId(int id)
        {
            return await _context.Departamentos.Include(d => d.Funcionarios).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Adicionar(Departamento departamento)
        {
            await _context.Departamentos.AddAsync(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var departamento = await ObterPorId(id);
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
        }
    }
}