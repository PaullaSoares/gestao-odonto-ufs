using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class LicaoQuestaoRepositorio : BaseRepositorio<LicaoQuestao>
    {
        internal LicaoQuestaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}