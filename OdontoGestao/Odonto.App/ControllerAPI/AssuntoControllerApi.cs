using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.ControllerApi
{
    [Produces("application/json")]
    [Route("api/assunto")]
    public class AssuntoControllerApi : Controller
    {
        private readonly Contexto _context;

        public AssuntoControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/Assunto
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Assunto> GetAssuntos()
        {
            return _context.Assuntos.Where(a => a.Subtopicos.Any()).OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/Assunto/5
        [HttpGet("{id}", Name = "GetAssunto")]
        [AllowAnonymous]
        public Assunto GetAssunto(int id)
        {
            return _context.Assuntos.SingleOrDefault(a => a.Id == id);
        }
    }
}
