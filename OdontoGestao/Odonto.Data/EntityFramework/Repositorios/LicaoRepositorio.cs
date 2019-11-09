using System;
using System.Collections.Generic;
using System.Text;
using Odonto.Core.Models;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public class LicaoRepositorio : BaseRepositorio<Assunto>
    {
        internal LicaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}