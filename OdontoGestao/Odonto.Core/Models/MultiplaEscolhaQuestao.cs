using System;
using System.Collections.Generic;

namespace Odonto.Core.Models
{
    public class MultiplaEscolhaQuestao
    {
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }

        public IEnumerable<Resposta> Respostas { get; set; }
        public DateTime DataHoraModificacao { get; set; }
    }
}
