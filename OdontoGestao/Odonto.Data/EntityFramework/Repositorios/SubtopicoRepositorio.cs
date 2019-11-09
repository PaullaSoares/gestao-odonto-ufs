using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class SubtopicoRepositorio : BaseRepositorio<Assunto>
    {
        internal SubtopicoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}