using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.WebApp.ControllerApi
{
    [Produces("application/json")]
    [Route("api/appaccount")]
    public class MobileUserControllerApi : Controller
    {
        private readonly Contexto _context;

        public MobileUserControllerApi(Contexto context)
        {
            _context = context;
        }

        // GET: api/appaccount
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MobileUser> GetMobileUsers()
        {
            return _context.MobileUsers.OrderByDescending(a => a.Id).ToList();
        }

        // GET: api/appaccount/teste@teste.com
        [HttpGet("{email}", Name = "GetMobileUser")]
        [AllowAnonymous]
        public MobileUser GetMobileUser(string email)
        {
            return _context.MobileUsers.SingleOrDefault(a => a.Login.Equals(email));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(string login, string senha)
        {
            var userDb = _context.MobileUsers.SingleOrDefault(a => a.Login.Equals(login));

            if (userDb != null)
            {
                if (userDb.Password.Equals(senha))
                    return Ok();

                return BadRequest("Senha incorreta");
            }

            return BadRequest("Login inválido");
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMobileUser(string login, string senha)
        {
            var userDb = _context.MobileUsers.SingleOrDefault(a => a.Login.Equals(login));

            if (userDb != null)
            {
                if (userDb.IsGoogle)
                    return BadRequest("Usuário já existe, com um vínculo com o Google");
                if (userDb.IsFacebook)
                    return BadRequest("Usuário já existe, com um vínculo com o Facebook");

                return BadRequest("Usuário já cadastrado");
            }

            var user = _context.MobileUsers.Add(new MobileUser
            {
                Login = login,
                Password = senha,
                IsGoogle = false,
                IsFacebook = false,
                DataHoraModificacao = DateTime.Now
            }).Entity;

            await _context.SaveChangesAsync();

            if (user != null)
                return Ok();

            return BadRequest("Houve um problema ao criar o usuário");
        }

        [HttpPost]
        [Route("registerExternal")]
        [AllowAnonymous]
        public IActionResult CreateMobileUserExternal(string login, bool isGoogle, bool isFacebook)
        {
            var userDb = _context.MobileUsers.SingleOrDefault(a => a.Login.Equals(login));

            if (userDb != null)
            {
                if (userDb.IsGoogle)
                    return BadRequest("Usuário já existe, com um vínculo com o Google");
                if (userDb.IsFacebook)
                    return BadRequest("Usuário já existe, com um vínculo com o Facebook");

                return BadRequest("Usuário já cadastrado");
            }

            var user = _context.MobileUsers.Add(new MobileUser
            {
                Login = login,
                Password = "",
                IsGoogle = isGoogle,
                IsFacebook = isFacebook
            }).Entity;

            if (user != null)
                return Ok();

            return BadRequest("Houve um problema ao criar o usuário");
        }
    }
}