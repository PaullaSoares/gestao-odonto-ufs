
namespace Odonto.Core.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        public string Opcao { get; set; }
        public string Texto { get; set; }

        public Questao Questao { get; set; }
        public int QuestaoId { get; set; }
    }
}
