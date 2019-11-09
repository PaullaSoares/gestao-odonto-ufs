using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Odonto.Core.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        [Description("Descrição")]
        public string Descricao { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        public IEnumerable<Questao> Questoes { get; set; }
    }
}