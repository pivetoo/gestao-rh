using GestorRH.Dominio.ValueObjects;

namespace GestorRH.Application.DTOs
{
    public class BatidaPontoDTO
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoBatida { get; set; }
    }
}
