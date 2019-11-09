using System;
using System.Collections.Generic;
using System.Text;

namespace Odonto.Core.Models
{
    public class Assunto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataHoraModificacao { get; set; }

        public IEnumerable<Topico> Subtopicos { get; set; }
    }
}
