namespace GestorRH.Dominio.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SalarioBase { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
