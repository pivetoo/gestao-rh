namespace GestorRH.Dominio.Entities
{
    public class Ferias
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        public Ferias(int id, int funcionarioId, DateTime dataInicio, DateTime dataFim)
        {
            Id = id;
            FuncionarioId = funcionarioId;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
