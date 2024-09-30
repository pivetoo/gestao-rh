namespace GestorRH.Dominio.Entities
{
    public class Relatorio
    {
        public int Id { get; set; }
        public DateTime DataGeracao { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }

        public Relatorio(int id, DateTime dataGeracao, string descricao, string conteudo)
        {
            Id = id;
            DataGeracao = DateTime.UtcNow;
            Descricao = descricao;
            Conteudo = conteudo;
        }
    }
}
