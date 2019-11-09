using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.ControllerApi
{
    [Produces("application/json")]
    [Route("api/licao")]
    public class LicaoControllerApi : Controller
    {
        private readonly Contexto _context;

        public LicaoControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/Licao
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Licao> GetLicoes()
        {
            return _context.Licoes.OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/Licao/5
        [HttpGet("{id}", Name = "GetLicao")]
        [AllowAnonymous]
        public Licao GetLicao(int id)
        {
            return _context.Licoes.SingleOrDefault(a => a.Id == id);
        }
    }
}