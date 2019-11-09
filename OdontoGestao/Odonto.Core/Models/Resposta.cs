using System;
using System.Collections.Generic;

namespace Odonto.Core.Models
{
    public class Resposta
    {
        public int Id { get; set; }

        public string Texto { get; set; }
        public bool Correta { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
    }
}
