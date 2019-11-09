using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class AssuntoRepositorio : BaseRepositorio<Assunto>
    {
        internal AssuntoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}