using GestorRH.Dominio.Entities;
using GestorRH.Dominio.Interfaces;
using GestorRH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly ApplicationDbContext _context;

        public CargoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> ObterTodos()
        {
            return await _context.Cargos.Include(c => c.Funcionarios).ToListAsync();
        }

        public async Task<Cargo> ObterPorId(int id)
        {
            return await _context.Cargos.Include(c => c.Funcionarios).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Adicionar(Cargo cargo)
        {
            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cargo cargo)
        {
            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var cargo = await ObterPorId(id);
            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
        }
    }
}
