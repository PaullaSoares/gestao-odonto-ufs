using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Odonto.Core.Models;

namespace Odonto.App.Models.LicaoViewModel
{
    public class LicaoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Tópico")]
        public int TopicoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Lição")]
        public string TextoLicao { get; set; }
    }
}
