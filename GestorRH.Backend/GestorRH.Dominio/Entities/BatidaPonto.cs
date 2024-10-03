using GestorRH.Dominio.ValueObjects;

namespace GestorRH.Dominio.Entities
{
    public class BatidaPonto
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataHora { get; set; }
        public TipoBatida TipoBatida { get; set; }

        public BatidaPonto(int funcionarioId, DateTime dataHora, TipoBatida tipoBatida)
        {
            FuncionarioId = funcionarioId;
            DataHora = dataHora == default ? DateTime.UtcNow : dataHora;
            TipoBatida = tipoBatida;
        }
    }
}
