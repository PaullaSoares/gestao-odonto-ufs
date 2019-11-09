using System;
using System.Collections.Generic;

namespace Odonto.Core.Models
{
    public class ExercicioQuestao
    {
        public int ExercicioId { get; set; }
        public Exercicio Exercicio { get; set; }

        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }

        public DateTime DataHoraModificacao { get; set; }
    }
}