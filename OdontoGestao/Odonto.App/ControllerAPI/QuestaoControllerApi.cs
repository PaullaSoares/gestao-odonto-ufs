using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.ControllerApi
{
    [Produces("application/json")]
    [Route("api/questao")]
    public class QuestaoControllerApi : Controller
    {
        private readonly Contexto _context;

        public QuestaoControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/Questao
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Questao> GetQuestoes()
        {
            return _context.Questoes.OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/Questao/5
        [HttpGet("{id}", Name = "GetQuestao")]
        [AllowAnonymous]
        public Questao GetQuestao(int id)
        {
            return _context.Questoes.SingleOrDefault(a => a.Id == id);
        }
    }
}