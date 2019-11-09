using System;
using System.Collections.Generic;

namespace Odonto.Core.Models
{
    public class LicaoQuestao
    {
        public int LicaoId { get; set; }
        public Licao Licao { get; set; }

        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }

        public DateTime DataHoraModificacao { get; set; }
    }
}