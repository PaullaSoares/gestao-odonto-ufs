using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class ExercicioQuestaoRepositorio : BaseRepositorio<ExercicioQuestao>
    {
        internal ExercicioQuestaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}