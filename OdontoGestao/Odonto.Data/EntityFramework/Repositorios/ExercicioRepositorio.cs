using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class ExercicioRepositorio : BaseRepositorio<Exercicio>
    {
        internal ExercicioRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}