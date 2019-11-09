using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Odonto.Core.Models
{
    public class Topico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        public int? AssuntoId { get; set; }
        public Assunto Assunto { get; set; }

        public int? TopicoPaiId { get; set; }
        [DisplayName("Topico Pai")]
        public Topico TopicoPai { get; set; }

        public IEnumerable<Topico> Subtopicos { get; set; }
        public IEnumerable<Licao> Licoes { get; set; }
    }
}
