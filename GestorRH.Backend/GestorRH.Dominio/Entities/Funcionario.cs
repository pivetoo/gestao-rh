using GestorRH.Dominio.ValueObjects;

namespace GestorRH.Dominio.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public Endereco Endereco { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<BatidaPonto> BatidasPonto { get; private set; }

        public void RegistrarPonto(DateTime dataHora, TipoBatida tipoBatida)
        {
            var batida = new BatidaPonto(Id, dataHora, tipoBatida);
            BatidasPonto.Add(batida);
        }
    }
}
