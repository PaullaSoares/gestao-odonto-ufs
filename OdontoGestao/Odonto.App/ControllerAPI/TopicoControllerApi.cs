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
    [Route("api/topico")]
    public class TopicoControllerApi : Controller
    {
        private readonly Contexto _context;

        public TopicoControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/Topico
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Topico> GetTopicos()
        {
            return _context.Topicos.Include(t => t.Subtopicos)
                .Where(t => !t.Subtopicos.Any())
                .Where(t => t.Licoes.Any())
                .OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/Topico/5
        [HttpGet("{id}", Name = "GetTopico")]
        [AllowAnonymous]
        public Topico GetTopico(int id)
        {
            return _context.Topicos.SingleOrDefault(a => a.Id == id);
        }
    }
}