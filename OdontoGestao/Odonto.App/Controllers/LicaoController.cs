using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Models;
using Odonto.Data.EntityFramework;

namespace Odonto.app.Controllers
{
    public class LicaoController : Controller
    {
        private readonly Contexto _context;

        public LicaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Licao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Licoes.Include(l => l.Topico).OrderByDescending(l => l.Id);
            return View(await contexto.ToListAsync());
        }

        // GET: Licao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licao = await _context.Licoes
                .Include(l => l.Topico)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licao == null)
            {
                return NotFound();
            }

            return View(licao);
        }

        // GET: Licao/Create
        public IActionResult Create()
        {
            var topicos = from t in _context.Topicos
                          where !_context.Topicos.Any(m => m.TopicoPaiId == t.Id)
                          select t;

            ViewData["Topicos"] = new SelectList(topicos.ToList(), "Id", "Titulo");
            return View();
        }

        // POST: Licao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,TextoLicao,HtmlLicao,TopicoId")] Licao licao)
        {
            if (ModelState.IsValid)
            {
                licao.DataHoraModificacao = DateTime.Now;
                _context.Add(licao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var topicos = from t in _context.Topicos
                          where !_context.Topicos.Any(m => m.TopicoPaiId == t.Id)
                          select t;

            ViewData["Topicos"] = new SelectList(topicos.ToList(), "Id", "Titulo");
            return View(licao);
        }

        // GET: Licao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licao = await _context.Licoes.SingleOrDefaultAsync(m => m.Id == id);
            if (licao == null)
            {
                return NotFound();
            }

            var topicos = from t in _context.Topicos
                          where !_context.Topicos.Any(m => m.TopicoPaiId == t.Id)
                          select t;

            ViewData["Topicos"] = new SelectList(topicos.ToList(), "Id", "Titulo", licao.TopicoId);
            return View(licao);
        }

        // POST: Licao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,TextoLicao,HtmlLicao,TopicoId")] Licao licao)
        {
            if (id != licao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    licao.DataHoraModificacao = DateTime.Now;
                    _context.Update(licao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicaoExists(licao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var topicos = from t in _context.Topicos
                          where !_context.Topicos.Any(m => m.TopicoPaiId == t.Id)
                          select t;

            ViewData["Topicos"] = new SelectList(topicos.ToList(), "Id", "Titulo", licao.TopicoId);
            return View(licao);
        }

        // GET: Licao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licao = await _context.Licoes
                .Include(l => l.Topico)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (licao == null)
            {
                return NotFound();
            }

            return View(licao);
        }

        // POST: Licao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licao = await _context.Licoes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Licoes.Remove(licao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicaoExists(int id)
        {
            return _context.Licoes.Any(e => e.Id == id);
        }
    }
}
