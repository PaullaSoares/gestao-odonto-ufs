using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class QuestaoRepositorio : BaseRepositorio<Questao>
    {
        internal QuestaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}