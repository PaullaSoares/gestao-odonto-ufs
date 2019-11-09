using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Odonto.Core.Models
{
    public class Questao
    {
        public int Id { get; set; }

        [Description("Pergunta")]
        public string TextoPergunta { get; set; }
        public string Resposta { get; set; }
        public string HtmlPergunta { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        //public IEnumerable<LicaoQuestao> Licoes { get; set; }

        public int ExercicioId { get; set; }
        [Description("Exercício")]
        public Exercicio Exercicio { get; set; }

        //public MultiplaEscolhaQuestao MultiplaEscolhaQuestao { get; set; }
    }
}
