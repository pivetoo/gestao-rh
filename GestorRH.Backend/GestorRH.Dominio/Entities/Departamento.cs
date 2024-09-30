namespace GestorRH.Dominio.Entities
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
