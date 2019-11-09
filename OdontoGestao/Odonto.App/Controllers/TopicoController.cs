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
    public class TopicoController : Controller
    {
        private readonly Contexto _context;

        public TopicoController(Contexto context)
        {
            _context = context;
        }

        // GET: Topico
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Topicos.Include(t => t.Assunto).OrderByDescending(t => t.Id);
            return View(await contexto.ToListAsync());
        }

        // GET: Topico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos
                .Include(t => t.Assunto)
                .Include(t => t.TopicoPai)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (topico == null)
            {
                return NotFound();
            }

            return View(topico);
        }

        // GET: Topico/Create
        public IActionResult Create()
        {
            ViewData["Assuntos"] = new SelectList(_context.Assuntos, "Id", "Titulo");
            ViewData["Topicos"] = new SelectList(_context.Topicos, "Id", "Titulo");
            return View();
        }

        // POST: Topico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AssuntoId,TopicoPaiId")] Topico topico)
        {
            if (ModelState.IsValid)
            {
                topico.DataHoraModificacao = DateTime.Now;
                _context.Add(topico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Assuntos"] = new SelectList(_context.Assuntos, "Id", "Titulo");
            ViewData["Topicos"] = new SelectList(_context.Topicos, "Id", "Titulo");
            return View(topico);
        }

        public IActionResult CreateModal()
        {
            ViewData["Assuntos"] = new SelectList(_context.Assuntos, "Id", "Titulo");
            ViewData["Topicos"] = new SelectList(_context.Topicos, "Id", "Titulo");
            return View();
        }

        // POST: Topico/CreateModal
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void CreateModal([Bind("Id,Titulo,AssuntoId,TopicoPaiId")] Topico topico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topico);
                _context.SaveChanges();
            }
        }

        // GET: Topico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos.SingleOrDefaultAsync(m => m.Id == id);
            if (topico == null)
            {
                return NotFound();
            }
            ViewData["Assuntos"] = new SelectList(_context.Assuntos, "Id", "Titulo");
            ViewData["Topicos"] = new SelectList(_context.Topicos, "Id", "Titulo");
            return View(topico);
        }

        // POST: Topico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AssuntoId,TopicoPaiId")] Topico topico)
        {
            if (id != topico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    topico.DataHoraModificacao = DateTime.Now;
                    _context.Update(topico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicoExists(topico.Id))
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
            ViewData["Assuntos"] = new SelectList(_context.Assuntos, "Id", "Titulo");
            ViewData["Topicos"] = new SelectList(_context.Topicos, "Id", "Titulo");
            return View(topico);
        }

        // GET: Topico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topico = await _context.Topicos
                .Include(t => t.Assunto)
                .Include(t => t.TopicoPai)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (topico == null)
            {
                return NotFound();
            }

            return View(topico);
        }

        // POST: Topico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topico = await _context.Topicos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Topicos.Remove(topico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicoExists(int id)
        {
            return _context.Topicos.Any(e => e.Id == id);
        }
    }
}
