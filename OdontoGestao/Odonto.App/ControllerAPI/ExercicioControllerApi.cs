using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.ControllerApi
{
    [Produces("application/json")]
    [Route("api/exercicio")]
    public class ExercicioControllerApi : Controller
    {
        private readonly Contexto _context;

        public ExercicioControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/Exercicio
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Exercicio> GetExercicios()
        {
            return _context.Exercicios
                .Where(t => t.Questoes.Any())
                .OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/Exercicio/5
        [HttpGet("{id}", Name = "GetExercicio")]
        [AllowAnonymous]
        public Exercicio GetExercicio(int id)
        {
            return _context.Exercicios.SingleOrDefault(a => a.Id == id);
        }
    }
}