using GestorRH.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Ferias> Ferias { get; set; }
        public DbSet<BatidaPonto> BatidasPonto { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Cargo)
                .WithMany()
                .HasForeignKey(f => f.CargoId);

            modelBuilder.Entity<BatidaPonto>()
                .HasOne(bp => bp.Funcionario)
                .WithMany()
                .HasForeignKey(bp => bp.FuncionarioId);
        }
    }
}
