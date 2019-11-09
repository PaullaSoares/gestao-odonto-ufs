using System;
using System.Collections.Generic;
using System.Text;

namespace Odonto.Core.Models
{
    public class Licao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TextoLicao { get; set; }
        public string HtmlLicao { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        public int TopicoId { get; set; }
        public Topico Topico { get; set; }

        //public IEnumerable<LicaoQuestao> Questoes { get; set; }
    }
}