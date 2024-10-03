namespace GestorRH.Dominio.Entities
{
    public class Relatorio
    {
        public int Id { get; set; }
        public DateTime DataGeracao { get; set; } = DateTime.UtcNow;
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
    }
}
