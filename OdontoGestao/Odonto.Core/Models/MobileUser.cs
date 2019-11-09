using System;
using System.Collections.Generic;
using System.Text;

namespace Odonto.Core.Models
{
    public class MobileUser
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsGoogle { get; set; }
        public bool IsFacebook { get; set; }

        public string Nome { get; set; }
        public string FotoPerfilBase64 { get; set; }
        public DateTime DataHoraModificacao { get; set; }
    }
}
